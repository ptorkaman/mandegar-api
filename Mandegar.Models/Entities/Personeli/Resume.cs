using Mandegar.Models.Base;
using Mandegar.Models.Entities.BaseInfo;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// سوابق کاری
    /// </summary>
    public class Resume : LoggableEntity<int>
    {
        public Resume()
        {

        }

        /// <summary>
        /// کد پرسنل
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// کد نوع سابقه کاری
        /// </summary>
        public int? WorkExperienceTypeId { get; set; }

        /// <summary>
        /// کد سال تحصیلی
        /// </summary>
        public int? AcademicYearId { get; set; }

        /// <summary>
        /// کد نوع همکاری
        /// </summary>
        public int? CooperationTypeId { get; set; }

        /// <summary>
        /// کد زمنیه فعالیت
        /// </summary>
        public int? ActivityFieldId { get; set; }

        /// <summary>
        /// نام محل خدمت
        /// </summary>
        public string WorkPlaceName { get; set; }

        /// <summary>
        /// مدت فعالیت
        /// </summary>
        public int? ActivityDuration { get; set; }

        /// <summary>
        /// کد سمت
        /// </summary>
        public int? PositionId { get; set; }

        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime EndDate { get; set; }

        #region Relation

        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(WorkExperienceTypeId))]
        public virtual WorkExperienceType WorkExperienceType { get; set; }

        [ForeignKey(nameof(CooperationTypeId))]
        public virtual CooperationType CooperationType { get; set; }

        [ForeignKey(nameof(ActivityFieldId))]
        public virtual ActivityField ActivityField { get; set; }

        [ForeignKey(nameof(AcademicYearId))]
        public virtual AcademicYear AcademicYear { get; set; }

        [ForeignKey(nameof(PositionId))]
        public virtual Position Position { get; set; }
        #endregion
    }
}
