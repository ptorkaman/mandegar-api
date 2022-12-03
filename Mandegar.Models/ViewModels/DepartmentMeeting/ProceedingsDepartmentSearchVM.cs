using Mandegar.Models.ViewModels.Common;
using System;


namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class ProceedingsDepartmentSearchVM: PageListVM
    {
        public int? DepartmentMeetingId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string Programs { get; set; }
        public string Comments { get; set; }
        public string Description { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
    }
}
