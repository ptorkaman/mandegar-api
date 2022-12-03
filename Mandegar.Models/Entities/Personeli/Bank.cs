using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// بانک
    /// </summary>
    public class Bank : LoggableEntity<int>
    {
        public Bank()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
