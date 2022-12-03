using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// مالی پرسنل
    /// </summary>
    public class StaffFinancial : LoggableEntity<int>
    {
        public StaffFinancial()
        {

        }

        /// <summary>
        /// شناسه پرسنل
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// شناسه بانک
        /// </summary>
        public int BankId { get; set; }

        /// <summary>
        /// شماره حساب
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        /// شماره شبا
        /// </summary>
        public string Sheba { get; set; }

        /// <summary>
        /// نام شعبه
        /// </summary>
        public string BranchName { get; set; }

        #region Raltion

        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }


        [ForeignKey(nameof(BankId))]
        public virtual Bank Bank{ get; set; }


        #endregion
    }
}
