using System;
using System.ComponentModel.DataAnnotations;

namespace Mandegar.Models.ViewModels.Account
{
    public class LoginFormVM
    {
        [Required(ErrorMessage = "{0} اجباری است")]
        [Display(Name = "نام کاربری")]
        public string Username { get; set; }

        [Required(ErrorMessage = "{0} اجباری است")]
        [Display(Name = "رمز عبور")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }

        [Required(ErrorMessage = "{0} اجباری است")]
        [Display(Name = "کد کپچا")]
        public string Captcha { get; set; }

        public Guid Key { get; set; }
    }
}
