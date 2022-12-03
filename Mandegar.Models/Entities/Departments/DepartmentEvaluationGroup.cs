using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// گروه ارزشيابي دپارتمان
    /// </summary>
    public class DepartmentEvaluationGroup : LoggableEntity<int>
    {
        public DepartmentEvaluationGroup()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
