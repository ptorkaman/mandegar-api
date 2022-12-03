using Mandegar.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// مصوبات جلسه
    /// </summary>
    public class SessionApprovals : LoggableEntity<int>
    {
        public SessionApprovals()
        {

        }

        /// <summary>
        /// کد برگزاری جلسه
        /// </summary>
        public int DepartmentMeetingId { get; set; }
                
        /// <summary>
        /// متن مصوبه
        /// </summary>
        public string Test { get; set; }

        /// <summary>
        /// تاریخ مهلت انجام کار
        /// </summary>
        public DateTime Deadline { get; set; }

        #region Relation

        [ForeignKey(nameof(DepartmentMeetingId))]
        public virtual DepartmentMeeting DepartmentMeeting { get; set; }

        public virtual ICollection<SessionApprovalMembers> SessionApprovalMembers { get; set; }

        #endregion
    }
}
