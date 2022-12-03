using Mandegar.Models.Base;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// اطلاعات خانواده پرسنل
    /// </summary>
    public class StaffFamilyInformation : LoggableEntity<int>
    {
        public StaffFamilyInformation()
        {

        }

        /// <summary>
        /// شناسه پرسنل
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        public string IdentityNumber { get; set; }

        /// <summary>
        /// کد ملی
        /// </summary>
        public string NationalCode { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime? BirthDate { get; set; }

        /// <summary>
        /// کد نسبت
        /// </summary>
        public int RelationId { get; set; }

        /// <summary>
        /// کد تحصیلات
        /// </summary>
        public int? EducationId { get; set; }

        /// <summary>
        /// رشته تحصیلی
        /// </summary>
        public string StudyField { get; set; }

        /// <summary>
        /// کد وضعیت تاهل
        /// </summary>
        public int? MaritalStatusId { get; set; }

        /// <summary>
        /// شغل
        /// </summary>
        public string Job { get; set; }

        /// <summary>
        /// تلفن
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// تلفن همراه
        /// </summary>
        public string Mobile { get; set; }

        /// <summary>
        /// آدرس محل کار
        /// </summary>
        public string WorkAddress { get; set; }

        /// <summary>
        /// تلفن محل کار
        /// </summary>
        public string WorkPhone { get; set; }

        /// <summary>
        /// پست الکترونیک
        /// </summary>
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        #region Raltion

        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(RelationId))]
        public virtual Relation Relation { get; set; }

        [ForeignKey(nameof(EducationId))]
        public virtual Education Education { get; set; }

        [ForeignKey(nameof(MaritalStatusId))]
        public virtual MaritalStatus  MaritalStatus{ get; set; }

        #endregion
    }
}
