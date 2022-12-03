namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class DepartmentMeetingAttendeesResultVM
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string MeetingName { get; set; }
        public int DepartmentMeetingId { get; set; }
        public int DepartmentMemberId { get; set; }
        public bool IsDeleted { get; set; }
    }
}
