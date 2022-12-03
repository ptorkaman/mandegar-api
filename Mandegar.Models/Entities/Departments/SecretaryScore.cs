using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// امتیاز به دبیر
    /// </summary>
    public class SecretaryScore : LoggableEntity<int>
    {
        public SecretaryScore()
        {

        }

        /// <summary>
        /// امتیاز
        /// </summary>
        public int Score { get; set; }

        /// <summary>
        /// کد ارزشیابی دبیر
        /// </summary>
        public int? SecretaryEvaluationId { get; set; }

        /// <summary>
        /// کد شاخص ارزشیابی
        /// </summary>
        public int? EvaluationIndicatorsId { get; set; }

        /// <summary>
        /// کد دوره ارزشیابی
        /// </summary>
        public int? EvaluationCourseId { get; set; }

        #region Relation

        [ForeignKey(nameof(SecretaryEvaluationId))]
        public virtual SecretaryEvaluation SecretaryEvaluation { get; set; }

        [ForeignKey(nameof(EvaluationIndicatorsId))]
        public virtual EvaluationIndicator EvaluationIndicator { get; set; }

        [ForeignKey(nameof(EvaluationCourseId))]
        public virtual EvaluationCourse EvaluationCourse { get; set; }


        #endregion
    }
}
