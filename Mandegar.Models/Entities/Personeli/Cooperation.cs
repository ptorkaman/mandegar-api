using Mandegar.Models.Base;
using Mandegar.Models.Entities.Departments;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{

    /// <summary>
    /// همکاری
    /// </summary>
    public class Cooperation : LoggableEntity<int>
    {
        public Cooperation()
        {

        }

        /// <summary>
        /// کد پرسنل
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// کد نوع همکاری
        /// </summary>
        public int CooperationTypeId { get; set; }

        /// <summary>
        /// کد دپارتمان
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// تاریخ شروع همکاری
        /// </summary>
        public DateTime? CooperationStartDate { get; set; }

        /// <summary>
        /// تاریخ پایان همکاری
        /// </summary>
        public DateTime? CooperationEndDate { get; set; }

        #region Relation

        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(CooperationTypeId))]
        public virtual CooperationType CooperationType { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        #endregion
    }
}
