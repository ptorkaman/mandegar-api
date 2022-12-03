﻿using Mandegar.Models.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.SessionApproval
{
    public class SessionApprovalQueryVM: PageListVM
    {
        public int? DepartmentMeetingId { get; set; }
        public string Test { get; set; }
        public DateTime? DeadlineFrom { get; set; }
        public DateTime? DeadlineTo { get; set; }
        public DataTable MemberIds { get; set; }
    }
}
