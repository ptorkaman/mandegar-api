using Mandegar.Models.Base;
using System;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// صورت جلسه دپارتمان
    /// </summary>
    public class ProceedingsDepartment : LoggableEntity<int>
    {
        public ProceedingsDepartment()
        {

        }

        /// <summary>
        /// کد برگزاری جلسه
        /// </summary>
        public int DepartmentMeetingId { get; set; }

        /// <summary>
        /// تاریخ شروع
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// تاریخ پایان
        /// </summary>
        public DateTime EndDate { get; set; }

        /// <summary>
        /// برنامه ها
        /// </summary>
        public string Programs { get; set; }

        /// <summary>
        /// نظرات
        /// </summary>
        public string Comments { get; set; }

        /// <summary>
        /// توضیحات جلسه
        /// </summary>
        public string Description { get; set; }

        #region Relation

        public virtual DepartmentMeeting DepartmentMeeting { get; set; }

        #endregion
    }
}
