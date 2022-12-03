using Mandegar.Utilities.BusinessHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.SessionApproval
{
    public class SessionApprovalResultVM
    {
        public int Id { get; set; }
        public int DepartmentMeetingId { get; set; }
        public string MeetingTitle { get; set; }
        public string Test { get; set; }
        public DateTime Deadline { get; set; }
        public string FullName { get; set; }
        public string PersianDeadline
        {
            get
            {
                return Convertor.ChangeDateTimeToPersianString(Deadline);
            }
        }
    }
}
