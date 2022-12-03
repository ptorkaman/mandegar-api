using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class AttendeesMembersVM
    {
        public string FullName { get; set; }
        public int Id { get; set; }
        public int DepartmentMeetingId { get; set; }
    }
}
