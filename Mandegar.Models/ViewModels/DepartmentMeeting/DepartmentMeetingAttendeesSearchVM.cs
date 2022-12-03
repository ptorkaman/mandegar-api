using Mandegar.Models.ViewModels.Common;
using Mandegar.Utilities.ExcelHelper.Attributes;
using System.Collections.Generic;
using System.Data;
using System.Text.Json.Serialization;

namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class DepartmentMeetingAttendeesSearchVM : PageListVM
    {
        public int? Id { get; set; }
        public int? DepartmentMeetingId { get; set; }
        public string MemberIds { get; set; }
    }
}
