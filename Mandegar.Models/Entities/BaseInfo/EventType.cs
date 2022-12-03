using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// نوع رویداد
    /// </summary>
    public class EventType : LoggableEntity<int>
    {
        public EventType()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
