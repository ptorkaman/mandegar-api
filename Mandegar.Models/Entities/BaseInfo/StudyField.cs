using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// رشته تحصیلی
    /// </summary>
    public class StudyField : LoggableEntity<int>
    {
        public StudyField()
        {

        }

        /// <summary>
        /// کد مقطع تحصیلی
        /// </summary>
       // public int StudyDefreeId { get; set; }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        #region Relation

        //[ForeignKey(nameof(StudyDefreeId))]
        //public virtual StudyDegree StudyDegree { get; set; }

        #endregion
    }
}
