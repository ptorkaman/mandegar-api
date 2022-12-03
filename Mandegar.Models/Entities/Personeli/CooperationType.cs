using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// نوع همکاری
    /// </summary>
    public class CooperationType : LoggableEntity<int>
    {
        public CooperationType()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}
