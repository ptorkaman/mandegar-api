using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// دوره ارزشیابی
    /// </summary>
    public class EvaluationCourse : LoggableEntity<int>
    {
        public EvaluationCourse()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// وضعیت
        /// </summary>
        public int Status { get; set; }
    }
}
