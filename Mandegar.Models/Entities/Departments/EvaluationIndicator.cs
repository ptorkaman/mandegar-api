using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// شاخص های ارزشیابی
    /// </summary>
    public class EvaluationIndicator : LoggableEntity<int>
    {
        public EvaluationIndicator()
        {

        }

        /// <summary>
        /// کد گروه ارزشیابی
        /// </summary>
        public int DepartmentEvaluationGroupId { get; set; }

        /// <summary>
        /// کد دروس دپارتمان
        /// </summary>
        public int DepartmentLessonId { get; set; }

        /// <summary>
        /// شاخص - سوال
        /// </summary>
        public string Question { get; set; }


        /// <summary>
        /// سقف امتیاز
        /// </summary>
        public int ScoreCeiling { get; set; }

        #region Relation

        [ForeignKey(nameof(DepartmentEvaluationGroupId))]
        public virtual DepartmentEvaluationGroup DepartmentEvaluationGroup { get; set; }

        [ForeignKey(nameof(DepartmentLessonId))]
        public virtual DepartmentLesson DepartmentLesson { get; set; }

        #endregion
    }
}
