using Mandegar.Models.Entities.User;
using System;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class ExecutiveCalendarVM
    {

        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        public int Id { get; set; }

     

        /// <summary>
        /// کد سال تحصیلی
        /// </summary>
        public int AcademicYearId { get; set; }
        public string AcademicYearName { get; set; }
    }
}
