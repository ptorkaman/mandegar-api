using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// مورد فعالیت
    /// </summary>
    public class ActivityCase : LoggableEntity<int>
    {
        public ActivityCase()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
