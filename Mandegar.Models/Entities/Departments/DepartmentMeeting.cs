using Mandegar.Models.Base;
using Mandegar.Resources.AdminMessage;
using Mandegar.Resources.ValidationMessage;
using Mandegar.Utilities.BusinessHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Departments
{
    /// <summary>
    /// برگزاری جلسات دپارتمان
    /// </summary>
    public class DepartmentMeeting : LoggableEntity<int>
    {
        public DepartmentMeeting()
        {

        }

        /// <summary>
        /// کد برنامه دپارتمان
        /// </summary>
        public int DepartmentScheduleId { get; set; }

        /// <summary>
        /// نام برنامه دپارتمان
        /// </summary>
        [NotMapped]
        public string DepartmentScheduleName { get; set; }

        /// <summary>
        /// عنوان جلسه
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime MeetingDate { get; set; }

        /// <summary>
        /// تاریخ شمسی
        /// </summary>
        [NotMapped]
        public string PersianDate
        {
            get
            {
                return Convertor.ChangeDateTimeToPersianString(MeetingDate);
            }
        }

        [NotMapped]
        public string Time
        {
            get
            {
                var ts = MeetingDate.TimeOfDay;
                return string.Format("{0:00}:{1:00}", ts.Hours, ts.Minutes);
            }
        }

        
        #region Relation

        [ForeignKey(nameof(DepartmentScheduleId))]
        public virtual DepartmentSchedule DepartmentSchedule { get; set; }

        public virtual ICollection<DepartmentMeetingMember> DepartmentMeetingMembers { get; set; }
        

        #endregion
    }
}
