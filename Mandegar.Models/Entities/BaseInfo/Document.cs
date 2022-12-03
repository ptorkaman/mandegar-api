using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// مدارک
    /// </summary>
    public class Document : LoggableEntity<int>
    {
        public Document()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// وضعیت مدرک
        /// </summary>
        public int Status { get; set; }


        /// <summary>
        /// مختص
        /// </summary>
        public string Specific { get; set; }
    }
}
