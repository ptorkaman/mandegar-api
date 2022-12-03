using Mandegar.CoreBase.Controller;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Account;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    /// <summary>
    /// حساب کاربری
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ApiBaseController
    {
        private readonly IUserService _userService;
        private readonly ICaptchaService _captchaService;

        public AuthController(IUserService userService, ICaptchaService captchaService)
        {
            _userService = userService;
            _captchaService = captchaService;
        }

        /// <summary>
        /// دریافت توکن
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("GetToken")]
        public async Task<Result<TokenVM>> GetToken([FromBody] LoginFormVM user)
        {
            #region Check Captcha

            bool isValidCaptcha = _captchaService.IsValid(user.Key, user.Captcha);
            if (isValidCaptcha == false)
            {
                return new Result<TokenVM>(Messages.CaptchaIsInvalid);
            }

            #endregion

            return await _userService.GetToken(user);
        }

        /// <summary>
        /// فراوشی رمز عبور
        /// </summary>
        /// <param name="forgotPasswordModel"></param>
        /// <returns></returns>
        [HttpPost("ForgotPassword")]
        public async Task<Result<bool>> ForgotPassword(ForgotPasswordVM forgotPasswordModel)
        {

            #region Check Captcha

            bool isValidCaptcha = _captchaService.IsValid(forgotPasswordModel.Key, forgotPasswordModel.Captcha);
            if (isValidCaptcha == false)
            {
                return new Result<bool>(Messages.CaptchaIsInvalid);
            }

            #endregion

            return await _userService.ForgotPassword(forgotPasswordModel);
        }

        /// <summary>
        /// چک کردن کد ریست رمز عبور
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        [HttpGet("ResetPasswordCodeExists")]
        public async Task<Result<bool>> ResetPasswordCodeExists(string requestCode)
        {
            return await _userService.GetResetPassword(requestCode);
        }

        /// <summary>
        /// ریست کردن رمز عبور
        /// </summary>
        /// <param name="resetPassword"></param>
        /// <returns></returns>
        [HttpPost("ResetPassword")]
        public async Task<Result<bool>> ResetPassword(ResetPasswordVM resetPassword)
        {

            #region Check Captcha

            bool isValidCaptcha = _captchaService.IsValid(resetPassword.Key, resetPassword.Captcha);
            if (isValidCaptcha == false)
            {
                return new Result<bool>(Messages.CaptchaIsInvalid);
            }

            #endregion

            return await _userService.ResetPassword(resetPassword);
        }

        /// <summary>
        /// ثبت نام کاربر
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        [HttpPost("Signup")]
        public async Task<Result<bool>> Signup(RegisterUserFormVM user)
        {

            #region Check Captcha

            bool isValidCaptcha = _captchaService.IsValid(user.Key, user.Captcha);
            if (isValidCaptcha == false)
            {
                return new Result<bool>(Messages.CaptchaIsInvalid);
            }

            #endregion

            return await _userService.Register(user);
        }

        /// <summary>
        /// تائید عضویت
        /// </summary>
        /// <param name="id">کد فعال سازی</param>
        /// <returns></returns>
        [HttpGet("ConfirmRegistration")]
        public async Task<Result<bool>> ConfirmRegistration(string activeCode)
        {
            var result = await _userService.ConfirmRegistration(activeCode);
            return result;
        }

        /// <summary>
        /// خروج از سامانه
        /// </summary>
        /// <returns></returns>
        [HttpPost("Logout")]
        public async Task<Result<bool>> Logout()
        {
            return new Result<bool>(true);
            //return await _userService.LogOut();
        }
    }
}
