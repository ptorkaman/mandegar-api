using Mandegar.Models.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class DepartmentMeetingMemberSearchVM : PageListVM
    {
        public int? DepartmentId { get; set; }
        public int? DepartmentMeetingId { get; set; }
        public string DepartmentMemberIds { get; set; }
    }

}
