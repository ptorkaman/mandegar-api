using Mandegar.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.Entities.Departments
{
    public class SessionApprovalMembers : LoggableEntity<int>
    {
        /// <summary>
        /// کد مصوبه
        /// </summary>
        public SessionApprovals SessionApprovals { get; set; }
        public int SessionApprovalsId { get; set; }
        /// <summary>
        /// کد اعضاء دپارتمان پیگیری
        /// </summary>
        //public DepartmentMeetingMember DepartmentMeetingMember { get; set; }
        public int DepartmentMeetingMemberId { get; set; }

    }
}
