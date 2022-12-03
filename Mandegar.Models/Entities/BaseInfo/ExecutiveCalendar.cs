using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// تقویم اجرایی
    /// </summary>
    public class ExecutiveCalendar : LoggableEntity<int>
    {
        public ExecutiveCalendar()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// کد سال تحصیلی
        /// </summary>
        public int AcademicYearId { get; set; }

        #region Relation

        [ForeignKey(nameof(AcademicYearId))]
        public virtual AcademicYear AcademicYear { get; set; }

        #endregion
    }
}
