using Mandegar.Models.Base;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// اعضاء جلسه
    /// </summary>
    public class DepartmentMeetingMember : LoggableEntity<int>
    {
        /// <summary>
        /// کد دپارتمان
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// کد برگزاری جلسه
        /// </summary>
        public int DepartmentMeetingId { get; set; }

        [ForeignKey(nameof(DepartmentId))]
        public virtual Department Department { get; set; }

        [ForeignKey(nameof(DepartmentMeetingId))]
        public virtual DepartmentMeeting DepartmentMeeting { get; set; }

        public virtual ICollection<MeetingMember> MeetingMembers { get; set; }
    }
}
