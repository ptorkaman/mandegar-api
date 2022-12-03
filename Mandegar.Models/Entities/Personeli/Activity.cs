using Mandegar.Models.Base;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Mandegar.Models.Entities.Personeli
{
    /// <summary>
    /// فعالیت
    /// </summary>
    public class Activity : LoggableEntity<int>
    {
        public Activity()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }


        /// <summary>
        /// موضوع
        /// </summary>
        public string Subject { get; set; }

        /// <summary>
        /// نام انتشارات
        /// </summary>
        public string PublicationName { get; set; }

        /// <summary>
        /// تاریخ نشر
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// کد پرسنل
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// نوع فعالیت
        /// </summary>
        public int ActivityTypeId { get; set; }

        /// <summary>
        /// مورد فعالیت
        /// </summary>
        public int ActivityCaseId { get; set; }

        #region Relation

        [ForeignKey(nameof(StaffId))]
        public virtual Staff Staff { get; set; }

        [ForeignKey(nameof(ActivityTypeId))]
        public virtual ActivityType ActivityType { get; set; }

        [ForeignKey(nameof(ActivityCaseId))]
        public virtual ActivityCase ActivityCase { get; set; }

        #endregion
    }
}
