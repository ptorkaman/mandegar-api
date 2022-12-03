using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class DepartmentMeetingAttendeesVM
    {
        public DepartmentMeetingAttendeesVM()
        {
            MemberIds = new List<int>();
        }
        public int? Id { get; set; }

        public int DepartmentMeetingId { get; set; }
        public ICollection<int> MemberIds { get; set; }
    }
}
