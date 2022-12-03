using System;
using System.ComponentModel.DataAnnotations;


namespace Mandegar.Models.ViewModels.Account
{
    public class ResetPasswordVM
    {
        public string RequestCode { get; set; }

        [Display(Name = "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        public string Password { get; set; }

        [Display(Name = "تکرار کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [Compare("Password", ErrorMessage = "کلمه عبور و تکرار آن یکسان نیست")]
        public string RePassword { get; set; }

        public string Captcha { get; set; }

        public Guid Key { get; set; }

    }
}
