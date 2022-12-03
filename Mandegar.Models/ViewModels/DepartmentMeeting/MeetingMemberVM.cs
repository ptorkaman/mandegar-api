using Mandegar.Models.Entities.Departments;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class MeetingMemberVM
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int DepartmentMeetingId { get; set; }
        public ICollection<int> MemberIds { get; set; }
    }
}
