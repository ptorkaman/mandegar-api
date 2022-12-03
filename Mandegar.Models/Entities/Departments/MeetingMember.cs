using Mandegar.Models.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    public class MeetingMember : LoggableEntity<int>
    {
        /// <summary>
        /// کد اعضاء جلسه
        /// </summary>
        public int DepartmentMeetingMemberId { get; set; }
        /// <summary>
        /// کد اعضاء دپارتمان
        /// </summary>
        public int DepartmentMemberId { get; set; }

        [ForeignKey(nameof(DepartmentMemberId))]
        public DepartmentMember DepartmentMember { get; set; }
        [ForeignKey(nameof(DepartmentMeetingMemberId))]
        public DepartmentMeetingMember DepartmentMeetingMember { get; set; }
    }
}
