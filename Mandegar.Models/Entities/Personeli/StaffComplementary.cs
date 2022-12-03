using Mandegar.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// تکمیلی پرسنل
    /// </summary>
    public class StaffComplementary : LoggableEntity<int>
    {
        public StaffComplementary()
        {

        }

        /// <summary>
        /// کد پرسنل
        /// </summary>
        public int StaffId { get; set; }


        /// <summary>
        /// شاره گواهینامه
        /// </summary>
        public string CertificateNumber { get; set; }

        /// <summary>
        /// کد دین
        /// </summary>
        public int? ReligionId { get; set; }

        /// <summary>
        /// کد ملیت
        /// </summary>
        public int? NationalityId { get; set; }

        /// <summary>
        /// کد گروه خونی
        /// </summary>
        public int? BloodTypeId { get; set; }

        /// <summary>
        /// شماره سریال شناسنامه
        /// </summary>
        public string IdentitySerialNumber { get; set; }

        /// <summary>
        /// کد وضعیت تاهل
        /// </summary>
        public int? MaritalStatusId { get; set; }

        /// <summary>
        /// کد نظام وظیفه
        /// </summary>
        public int? MilitaryServiceStatusId { get; set; }

        /// <summary>
        /// تاریخ نظام وظیفه
        /// </summary>
        public DateTime? MilitaryServiceDate { get; set; }

        /// <summary>
        /// کد نوع بیمه
        /// </summary>
        public int? InsuranceTypeId { get; set; }

        /// <summary>
        /// شماره بیمه
        /// </summary>
        public string InsuranceNumber { get; set; }

        #region Relation

        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(ReligionId))]
        public virtual Religion Religion { get; set; }

        [ForeignKey(nameof(NationalityId))]
        public virtual Nationality Nationality { get; set; }

        [ForeignKey(nameof(BloodTypeId))]
        public virtual BloodType BloodType { get; set; }

        [ForeignKey(nameof(MaritalStatusId))]
        public virtual MaritalStatus MaritalStatus { get; set; }

        [ForeignKey(nameof(MilitaryServiceStatusId))]
        public virtual MilitaryServiceStatus MilitaryServiceStatus { get; set; }

        [ForeignKey(nameof(InsuranceTypeId))]
        public virtual InsuranceType InsuranceType { get; set; }

        #endregion
    }
}
