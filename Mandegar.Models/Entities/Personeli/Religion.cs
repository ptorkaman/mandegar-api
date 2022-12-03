using Mandegar.Models.Base;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// دین
    /// </summary>
    public class Religion : LoggableEntity<int>
    {
        public Religion()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
    }
}