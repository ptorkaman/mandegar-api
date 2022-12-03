using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// نوع سابقه کاری
    /// </summary>
    public class WorkExperienceType : LoggableEntity<int>
    {
        public WorkExperienceType()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
