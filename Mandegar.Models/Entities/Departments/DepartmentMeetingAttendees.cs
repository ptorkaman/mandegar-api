using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// حاضرین جلسه
    /// </summary>
    public class DepartmentMeetingAttendees : LoggableEntity<int>
    {
        public int DepartmentMeetingId { get; set; }
        public DepartmentMeeting DepartmentMeeting { get; set; }
        public int DepartmentMemberId { get; set; }
        public DepartmentMember DepartmentMember { get; set; }
    }
}
