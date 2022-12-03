using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// نوع فعالیت دپارتمان
    /// </summary>
    public class DepartmentActivityType : LoggableEntity<int>
    {
        public DepartmentActivityType()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
