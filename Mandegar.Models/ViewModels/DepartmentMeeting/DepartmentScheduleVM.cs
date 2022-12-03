using Mandegar.Models.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Models.ViewModels.DepartmentMeeting
{
    public class DepartmentScheduleVM : PageListVM
    {
        public int Id { get; set; }

        /// <summary>
        /// برنامه های دپارتمان
        /// </summary>
        public int ExecutiveCalendarId { get; set; }
        public string ExecutiveCalendarName { get; set; }

        /// <summary>
        /// عنوان برنامه های دپارتمان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// از تاریخ
        /// </summary>
        public DateTime? FromDate { get; set; }

        /// <summary>
        /// تا تاریخ
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// محدوده زمانی
        /// </summary>
        public string TimeLimit { get; set; }
    }
}
