using Mandegar.CoreBase.Controller;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Captcha;
using Mandegar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    /// <summary>
    /// کپچا
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class CaptchaController : ApiBaseController
    {

        private readonly ICaptchaService _captchaService;
        public CaptchaController(ICaptchaService captchaService)
        {
            _captchaService = captchaService;
        }

        /// <summary>
        /// ایجاد کد کپچا
        /// </summary>
        /// <returns></returns>
        [HttpGet("Create")]
        public async Task<CaptchaVM> Create()
        {
            return await _captchaService.Create();
        }
    }
}
