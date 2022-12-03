using Mandegar.Resources.ValidationMessage;
using Mandegar.Utilities.BusinessHelpers;
using System;
using System.ComponentModel.DataAnnotations;

namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class ProceedingsDepartmentVM
    {
        public int Id { get; set; }

        [Required(ErrorMessageResourceName = nameof(Validation.Required), ErrorMessageResourceType = typeof(Validation))]
        public int DepartmentMeetingId { get; set; }

        [Required(ErrorMessageResourceName = nameof(Validation.Required), ErrorMessageResourceType = typeof(Validation))]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessageResourceName = nameof(Validation.Required), ErrorMessageResourceType = typeof(Validation))]
        public DateTime EndDate { get; set; }

        public string Programs { get; set; }
        public string Comments { get; set; }
        public string DepartmentMeetingTitle { get; set; }
        public string Description { get; set; }

        public string PersianStartDate
        {
            get
            {
                return Convertor.ChangeDateTimeToPersianString(StartDate);
            }
        }

        public string PersianEndDate
        {
            get
            {
                return Convertor.ChangeDateTimeToPersianString(EndDate);
            }
        }

        public string ProceedingStartTime { get; set; }
        public string ProceedingEndTime { get; set; }

        public string StartTime
        {
            get
            {
                var ts = StartDate.TimeOfDay;
                return string.Format("{0:00}:{1:00}", ts.Hours, ts.Minutes);
            }
        }

        public string EndTime
        {
            get
            {
                var ts = EndDate.TimeOfDay;
                return string.Format("{0:00}:{1:00}", ts.Hours, ts.Minutes);
            }
        }

    }
}
