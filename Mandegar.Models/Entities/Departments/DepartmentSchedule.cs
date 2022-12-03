using Mandegar.Models.Base;
using Mandegar.Models.Entities.BaseInfo;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// برنامه های دپارتمان
    /// </summary>
    public class DepartmentSchedule : LoggableEntity<int>
    {
        public DepartmentSchedule()
        {

        }

        /// <summary>
        /// برنامه های دپارتمان
        /// </summary>
        public int ExecutiveCalendarId { get; set; }

        /// <summary>
        /// عنوان برنامه های دپارتمان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// از تاریخ
        /// </summary>
        public DateTime? FromDate{ get; set; }

        /// <summary>
        /// تا تاریخ
        /// </summary>
        public DateTime? ToDate { get; set; }

        /// <summary>
        /// محدوده زمانی
        /// </summary>
        public string TimeLimit { get; set; }

        #region Relation

        [ForeignKey(nameof(ExecutiveCalendarId))]
        public virtual ExecutiveCalendar ExecutiveCalendar { get; set; }

        #endregion
    }
}
