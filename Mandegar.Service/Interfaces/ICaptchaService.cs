using Mandegar.Models.ViewModels.Captcha;
using System;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ICaptchaService
    {
        Task<CaptchaVM> Create();

        bool IsValid(Guid Key, string captcha);
    }
}
