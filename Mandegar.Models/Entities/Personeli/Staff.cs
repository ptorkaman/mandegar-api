using Mandegar.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// پرسنل
    /// </summary>
    public class Staff : LoggableEntity<int>
    {
        public Staff()
        {

        }


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
        /// شهر محل تولد
        /// </summary>
        public int? BirthCityId { get; set; }

        /// <summary>
        /// شهر محل صدور شناسنامه
        /// </summary>
        public int? IdentityIssueCityId { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// تاریخ صدور شناسنامه
        /// </summary>
        public DateTime? IdentityIssueDate { get; set; }

        /// <summary>
        /// کد پرسنلی
        /// </summary>
        public string PersonneliCode { get; set; }

        /// <summary>
        /// جنسیت
        /// </summary>
        public bool Gender { get; set; }

        /// <summary>
        /// تصویر پرسنلی
        /// </summary>
        public string Image { get; set; }

        /// <summary>
        /// نام پدر
        /// </summary>
        public string FatherName { get; set; }

        #region Relation

        [ForeignKey(nameof(BirthCityId))]
        public virtual City BirthCity { get; set; }


        [ForeignKey(nameof(IdentityIssueCityId))]
        public virtual City IdentityIssueCity { get; set; }

        public virtual ICollection<EducationalQualification> EducationalQualifications { get; set; }

        public ICollection<AssignPosition> AssignPositions { get; set; }
        #endregion

    }
}
