using System;
using System.ComponentModel.DataAnnotations;

namespace Mandegar.Models.ViewModels.Account
{
    public class RegisterUserFormVM
    {
        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.EmailAddress, ErrorMessage = "ایمیل خود را به شکل صحیح وارد نمائید. youremail@example.com")]
        [Display(Name = "ایمیل")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password, ErrorMessage = "{0} را به طور صحیح وارد نمائید")]
        [Display(Name = "رمز عبور")]
        public string Password { get; set; }

        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password, ErrorMessage = "{0} را به طور صحیح وارد نمائید")]
        [Compare("Password", ErrorMessage = "رمز عبور با تکرار آن یکسان نیست")]
        [Display(Name = "رمز عبور")]
        public string RePassword { get; set; }

        [Required(ErrorMessage = "{0} اجباری است")]
        [Display(Name = "کد کپچا")]
        public string Captcha { get; set; }

        public Guid Key { get; set; }

    }
}
