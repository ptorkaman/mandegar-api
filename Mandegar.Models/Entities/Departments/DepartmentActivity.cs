using Mandegar.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    ///  فعالیت دپارتمان
    /// </summary>
    public class DepartmentActivity : LoggableEntity<int>
    {
        public DepartmentActivity()
        {

        }

        /// <summary>
        /// کد دپارتمان
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// عنوان فعالیت
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// شرح فعالیت
        /// </summary>
        public string ActivityDescription { get; set; }

        /// <summary>
        /// فایل ضمیمه
        /// </summary>
        public string AttachmentFile { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// شناسه نوع فعالیت دپارتمان
        /// </summary>
        public int? DepartmentActivityTypeId { get; set; }

        #region Relation

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        public virtual ICollection<DepartmentActivityMember> DepartmentActivityMembers { get; set; }

        [ForeignKey(nameof(DepartmentActivityTypeId))]
        public virtual DepartmentActivityType DepartmentActivityType { get; set; }

        #endregion
    }
}
