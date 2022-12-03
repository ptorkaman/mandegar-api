using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// نشانی پرسنل
    /// </summary>
    public class StaffAddress : LoggableEntity<int>
    {
        public StaffAddress()
        {

        }

        /// <summary>
        /// شناسه پرسنل
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// تلفن ثابت
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        /// تلفن همراه 1
        /// </summary>
        public string Mobile1 { get; set; }

        /// <summary>
        /// تلفن همراه 2
        /// </summary>
        public string Mobile2 { get; set; }

        /// <summary>
        /// نشانی محل سکونت
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        /// کد نوع محل سکونت
        /// </summary>
        public int? AddressTypeId { get; set; }

        /// <summary>
        /// نام محل کار دیگر
        /// </summary>
        public string OtherWorkName { get; set; }

        /// <summary>
        /// تلفن محل کار دیگر
        /// </summary>
        public string OtherWorkPhone { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// پست الکترونیک
        /// </summary>
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        #region Relation

        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(AddressTypeId))]
        public virtual AddressType AddressType { get; set; }

        #endregion
    }
}
