using Mandegar.Models.Entities.Personeli;
using System.Collections.Generic;


namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class DepartmentMeetingMemberVM
    {
        public int Id { get; set; }
        public int DepartmentId { get; set; }
        public int DepartmentMeetingId { get; set; }
        public string MeetingName { get; set; }
        public string DepartmentName { get; set; }
    }
}
