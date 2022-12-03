using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class DepartmentStaffVM
    {
        public int DepartmentMemberId { get; set; }
        public int DepartmentMeetingMemberId { get; set; }
        public int DepartmentId { get; set; }
        public string FullName { get; set; }
    }
}
