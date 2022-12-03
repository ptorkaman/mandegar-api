﻿using Microsoft.AspNetCore.Http;
using Mandegar.Services.Interfaces;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Drawing.Text;
using System.IO;
using System.Threading.Tasks;
using Mandegar.Utilities.BusinessHelpers;
using Mandegar.Models.ViewModels.Captcha;
using Mandegar.Services.Cache;

namespace Mandegar.Services.Impeliments
{
    public class CaptchaService : ICaptchaService
    {
        private readonly IMemoryCacheService _memoryCacheService;
        public CaptchaService(IMemoryCacheService memoryCacheService)
        {
            _memoryCacheService = memoryCacheService;
        }

        public async Task<CaptchaVM> Create()
        {
            return await Task.Run(() =>
            {
                bool noisy = true;

                var rand = new Random((int)DateTime.Now.Ticks);
                //generate new question
                int a = rand.Next(10, 89);
                int b = rand.Next(1, 9);
                var captcha = string.Empty;

                var random = new Random().Next(1, 10);
                var captchaResult = "0";
                if (random % 2 == 0)
                {
                    captcha = string.Format("{0} + {1}", a, b);
                    captchaResult = (a + b).ToString();
                }
                else
                {
                    captcha = string.Format("{0} - {1}", a, b);
                    captchaResult = (a - b).ToString();

                }

                //image stream
                using (var mem = new MemoryStream())
                using (var bmp = new Bitmap(120, 50))
                using (var gfx = Graphics.FromImage((Image)bmp))
                {
                    gfx.TextRenderingHint = TextRenderingHint.ClearTypeGridFit;
                    gfx.SmoothingMode = SmoothingMode.AntiAlias;
                    gfx.FillRectangle(Brushes.White, new Rectangle(0, 0, bmp.Width, bmp.Height));

                    //add noise
                    if (noisy)
                    {
                        int i, r, x, y;
                        var pen = new Pen(Color.Yellow);
                        for (i = 1; i < 10; i++)
                        {
                            pen.Color = Color.FromArgb(
                            (rand.Next(0, 255)),
                            (rand.Next(0, 255)),
                            (rand.Next(0, 255)));

                            r = rand.Next(0, (130 / 3));
                            x = rand.Next(0, 130);
                            y = rand.Next(0, 30);

                            gfx.DrawEllipse(pen, x - r, y - r, r, r);
                        }
                    }

                    //add question
                    gfx.DrawString(captcha, new Font("Tahoma", 25), Brushes.Gray, 2, 3);

                    //render as Jpeg
                    bmp.Save(mem, ImageFormat.Jpeg);

                    Guid key = Guid.NewGuid();

                    string image = Convert.ToBase64String(mem.ToArray());

                    this.GetOrSet(key, captchaResult);

                    return new CaptchaVM { Value = image, Key = key };

                };
            });
        }

        public bool IsValid(Guid Key, string captcha)
        {
            if (Convert.ToBoolean(AppsettingsGetter.Get("UiSettings:CheckCaptcha")) == false)
            {
                return true;
            }

            bool result = this.GetOrSet(Key, "") == captcha;
            this._memoryCacheService.Remove(Key);

            return result;
        }

        #region Privates
        private string GetOrSet(Guid key, string value)
        {
            return _memoryCacheService.GetOrSet(key, () => value, TimeSpan.FromMinutes(2));
        }
        #endregion
    }

}


