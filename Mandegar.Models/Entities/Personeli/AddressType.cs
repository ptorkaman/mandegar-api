using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// نوع محل سکونت
    /// </summary>
    public class AddressType : LoggableEntity<int>
    {
        public AddressType()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
