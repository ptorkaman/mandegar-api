using Mandegar.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// رویداد
    /// </summary>
    public class Event : LoggableEntity<int>
    {
        public Event()
        {

        }

        /// <summary>
        /// کد تقویم اجرایی
        /// </summary>
        public int ExecutiveCalendarId { get; set; }

        /// <summary>
        /// کد نوع رویداد
        /// </summary>
        public int EventTypeId { get; set; }

        /// <summary>
        /// تاریخ
        /// </summary>
        public DateTime EventDate { get; set; }

        /// <summary>
        /// عنوان برنامه
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// توضیحات
        /// </summary>
        public string Description { get; set; }

        #region Relation

        [ForeignKey(nameof(ExecutiveCalendarId))]
        public virtual ExecutiveCalendar ExecutiveCalendar { get; set; }

        [ForeignKey(nameof(EventTypeId))]
        public virtual EventType EventType { get; set; }

        #endregion
    }
}
