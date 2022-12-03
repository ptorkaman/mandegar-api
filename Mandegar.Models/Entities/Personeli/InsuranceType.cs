using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// نوع بیمه
    /// </summary>
    public class InsuranceType : LoggableEntity<int>
    {
        public InsuranceType()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
