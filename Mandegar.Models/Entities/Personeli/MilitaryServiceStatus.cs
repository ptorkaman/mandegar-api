using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// نظام وظیفه
    /// </summary>
    public class MilitaryServiceStatus : LoggableEntity<int>
    {
        public MilitaryServiceStatus()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
