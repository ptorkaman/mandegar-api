using Mandegar.Models.Base;
using System;

namespace Mandegar.Models.Entities.BaseInfo
{
    /// <summary>
    /// سال تحصیلی
    /// </summary>
    public class AcademicYear : LoggableEntity<int>
    {
        public AcademicYear()
        {

        }

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// از تاریخ
        /// </summary>
        public DateTime FromDate{ get; set; }

        /// <summary>
        /// تا تاریخ
        /// </summary>
        public DateTime ToDate { get; set; }
    }
}
