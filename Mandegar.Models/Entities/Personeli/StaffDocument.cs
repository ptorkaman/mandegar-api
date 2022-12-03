using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// مدارک پرسنل
    /// </summary>
    public class StaffDocument : LoggableEntity<int>
    {
        public StaffDocument()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// کد پرسنل
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// نوع فایل
        /// </summary>
        public string FileType { get; set; }

        /// <summary>
        /// عنوان فایل
        /// </summary>
        public string FileName { get; set; }

        #region Relation

        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }

        #endregion
    }
}
