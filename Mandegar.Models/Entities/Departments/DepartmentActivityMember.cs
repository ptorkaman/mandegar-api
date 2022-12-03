using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// ارتباط فعاليت دپارتمان با اعضا دپارتمان
    /// </summary>
    public class DepartmentActivityMember
    {
        public int DepartmentActivityId { get; set; }

        [ForeignKey(nameof(DepartmentActivityId))]
        public virtual DepartmentActivity DepartmentActivity { get; set; }

        public int DepartmentMemberId { get; set; }

        [ForeignKey(nameof(DepartmentMemberId))]
        public virtual DepartmentMember DepartmentMember { get; set; }
    }
}
