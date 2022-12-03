using System;
using System.ComponentModel.DataAnnotations;

namespace Mandegar.Models.ViewModels.Account
{
    public class ForgotPasswordVM
    {
        [Display(Name = "ایمیل")]
        [Required(ErrorMessage = "لطفا {0} را وارد نمائید.")]
        [MaxLength(100, ErrorMessage = "{0} نمی تواند بیشتر از {1} کاراکتر باشد")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده معتبر نمی باشد")]
        public string Email { get; set; }

        [Required(ErrorMessage = "{0} اجباری است")]
        [Display(Name = "کد کپچا")]
        public string Captcha { get; set; }

        public Guid Key { get; set; }
    }
}
