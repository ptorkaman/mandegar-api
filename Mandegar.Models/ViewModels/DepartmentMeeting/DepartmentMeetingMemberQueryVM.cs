using Mandegar.Models.ViewModels.Common;
using System.Data;

namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class DepartmentMeetingMemberQueryVM: PageListVM
    {
        public int? Id { get; set; }
        public int? DepartmentId { get; set; }
        public int? DepartmentMeetingId { get; set; }
        public DataTable MemberIds { get; set; }
    }
}
