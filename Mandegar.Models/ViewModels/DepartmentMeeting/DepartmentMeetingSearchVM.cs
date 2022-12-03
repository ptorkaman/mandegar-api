using Mandegar.Models.ViewModels.Common;
using System;
using System.ComponentModel.DataAnnotations;


namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class DepartmentMeetingSearchVM: PageListVM
    {
        public int? DepartmentScheduleId { get; set; }
        public DateTime? MeetingDate { get; set; }
        [StringLength(200)]
        public string Name { get; set; }
        public string Time { get; set; }
    }
}
