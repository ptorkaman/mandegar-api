using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// کلاس
    /// </summary>
    public class Class : LoggableEntity<int>
    {
        public Class()
        {

        }

        /// <summary>
        /// کد پایه تحصیلی
        /// </summary>
        public int StudyGradeId { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// کد کلاس
        /// </summary>
        public string Code { get; set; }

        #region Relation

        [ForeignKey(nameof(StudyGradeId))]
        public virtual StudyGrade StudyGrade { get; set; }

        #endregion
    }
}
