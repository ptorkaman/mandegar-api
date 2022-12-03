using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// نوع فعالیت
    /// </summary>
    public class ActivityType : LoggableEntity<int>
    {
        public ActivityType()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
