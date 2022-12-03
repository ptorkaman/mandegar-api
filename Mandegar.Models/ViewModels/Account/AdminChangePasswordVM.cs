
using System.ComponentModel.DataAnnotations;

namespace Mandegar.Models.ViewModels.Account
{
    public class AdminChangePasswordVM
    {
        [Display(Name = "رمز عبور جدید")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password)]
        public string newPassword { get; set; }

        [Display(Name = "رمز عبور فعلی")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password)]
        public string currentPassword { get; set; }

        [Display(Name = "تکرار رمز عبور جدید")]
        [Compare("newPassword", ErrorMessage = "رمز عبور جدید با تکرار آن یکسان نیست")]
        [Required(ErrorMessage = "{0} اجباری است")]
        [DataType(DataType.Password)]
        public string repeatNewPassword { get; set; }

        public int UserId { get; set; }
    }
}
