using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// کلاس سال تحصیلی
    /// </summary>
    public class YearClass : LoggableEntity<int>
    {
        public YearClass()
        {

        }

        /// <summary>
        /// کد سال تحصیلی
        /// </summary>
        public int AcademicYeardId { get; set; }

        /// <summary>
        /// کد کلاس سال تحصیلی
        /// </summary>
        public int ClassId { get; set; }

        #region Relation

        [ForeignKey(nameof(AcademicYeardId))]
        public virtual AcademicYear AcademicYear { get; set; }

        [ForeignKey(nameof(ClassId))]
        public virtual Class Class { get; set; }

        #endregion
    }
}
