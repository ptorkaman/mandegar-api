using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// مقطع تحصیلی
    /// </summary>
    public class StudyDegree : LoggableEntity<int>
    {
        public StudyDegree()
        {

        }

        /// <summary>
        /// عنوان مقطع تحصیلی
        /// </summary>
        public string Name { get; set; }
    }
}
