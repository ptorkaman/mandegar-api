using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// انواع درس
    /// </summary>
    public class LessonType : LoggableEntity<int>
    {
        public LessonType()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

    }
}
