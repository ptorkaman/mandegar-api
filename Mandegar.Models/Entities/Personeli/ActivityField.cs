using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// زمینه فعالیت
    /// </summary>
    public class ActivityField : LoggableEntity<int>
    {
        public ActivityField()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
