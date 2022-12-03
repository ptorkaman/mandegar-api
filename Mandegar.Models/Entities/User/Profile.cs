using Mandegar.Models.Base;
using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Mandegar.Models.Entities.User
{
    public class Profile : BaseEntity<int>
    {
        public Profile()
        {
            Name = Family = Email = NationalCode = string.Empty;
            Avatar = "/Images/UserAvatar/Default.jpg";
            Gender = true;
            LastLogin = null;
        }

        [Display(Name = "نام")]
        [DisplayName("نام")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(50)]
        public string Name { get; set; }

        [Display(Name = "نام خانوادگی")]
        [DisplayName("نام خانوادگی")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(50)]
        public string Family { get; set; }

        [Display(Name = "ایمیل")]
        [DisplayName("ایمیل")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(100)]
        [Required(ErrorMessage = "ایمیل اجباری است")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Display(Name = "موبایل")]
        [DisplayName("موبایل")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(25)]
        public string Mobile { get; set; }
        [Display(Name = "تاریخ تولد")]
        [DisplayName("تاریخ تولد")]
        public DateTime? BirthDate { get; set; }


        [Display(Name = "کد ملی")]
        [DisplayName("کد ملی")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(10)]
        public string NationalCode { get; set; }


        [Display(Name = "تصویر نمایه")]
        [DisplayName("تصویر نمایه")]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        [MaxLength(200)]
        public string Avatar { get; set; }

        [Display(Name = "جنسیت")]
        [DisplayName("جنست")]
        public bool Gender { get; set; }


        public DateTime? LastLogin { get; set; }

        #region Relations
        public virtual User User { get; set; }
        public int UserId { get; set; }

        #endregion
    }
}