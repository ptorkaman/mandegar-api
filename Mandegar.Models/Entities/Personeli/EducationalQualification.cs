using Mandegar.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// مدارک تحصیلی/آموزشی
    /// </summary>
    public class EducationalQualification : LoggableEntity<int>
    {
        public EducationalQualification()
        {

        }

        /// <summary>
        /// کد پرسنل
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// کد نوع مدرک
        /// </summary>
        public int EducationId { get; set; }

        /// <summary>
        /// کد نام مدرک
        /// </summary>
        public int DocumentId { get; set; }

        /// <summary>
        /// رشته/دوره آموزشی
        /// </summary>
        public string CourseName { get; set; }

        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime? StartDate { get; set; }


        /// <summary>
        /// مدت
        /// </summary>
        public int Period { get; set; }

        /// <summary>
        /// نام موسسه
        /// </summary>
        public string InstitutionName { get; set; }

        /// <summary>
        /// تاریخ اخذ مدرک
        /// </summary>
        public DateTime? DegreeReceiptDate { get; set; }

        #region Relation

        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(EducationId))]
        public virtual Education Education { get; set; }


        [ForeignKey(nameof(DocumentId))]
        public virtual StaffDocument StaffDocument { get; set; }

        #endregion
    }
}
