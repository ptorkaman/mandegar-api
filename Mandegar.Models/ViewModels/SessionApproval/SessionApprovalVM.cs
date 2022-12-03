using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.SessionApproval
{
    public class SessionApprovalVM
    {
        public int Id { get; set; }
        public int DepartmentMeetingId { get; set; }
        public string Test { get; set; }
        public DateTime Deadline { get; set; }
        public ICollection<int> MemberIds { get; set; }
    }
}
