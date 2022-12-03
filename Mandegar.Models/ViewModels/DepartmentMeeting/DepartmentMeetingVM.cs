using Mandegar.Resources.ValidationMessage;
using Mandegar.Utilities.BusinessHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class DepartmentMeetingVM
    {
        public int Id { get; set; }
        [Required(ErrorMessageResourceName = nameof(Validation.Required), ErrorMessageResourceType = typeof(Validation))]
        public int DepartmentScheduleId { get; set; }
        [StringLength(200, ErrorMessageResourceName = nameof(Validation.DepartmentMaxLength), ErrorMessageResourceType = typeof(Validation))]
        [Required(ErrorMessageResourceName = nameof(Validation.Required), ErrorMessageResourceType = typeof(Validation))]
        public string Name { get; set; }
        [Required(ErrorMessageResourceName = nameof(Validation.Required), ErrorMessageResourceType = typeof(Validation))]
        public DateTime MeetingDate { get; set; }
        [Required(ErrorMessageResourceName = nameof(Validation.Required), ErrorMessageResourceType = typeof(Validation))]
        public string Time { get; set; } 
    }
}
