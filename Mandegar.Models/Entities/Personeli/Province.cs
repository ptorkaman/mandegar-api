using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// استان
    /// </summary>
    public class Province : LoggableEntity<int>
    {
        public Province()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        #region Relation

        public int CountryId { get; set; }

        [ForeignKey(nameof(CountryId))]
        public virtual Country Country { get; set; }

        #endregion
    }
}
