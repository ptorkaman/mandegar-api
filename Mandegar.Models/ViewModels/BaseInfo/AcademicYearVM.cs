using Mandegar.Models.Entities.User;
using System;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class AcademicYearVM
    {
        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        public int Id { get; set; }

        /// <summary>
        /// از تاریخ
        /// </summary>
        public DateTime FromDate { get; set; }

        /// <summary>
        /// تا تاریخ
        /// </summary>
        public DateTime ToDate { get; set; }
    }
}
