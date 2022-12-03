using Mandegar.Models.Entities.User;
using System;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class StaffVM
    {
        /// <summary>
        /// نام
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// نام خانوادگی
        /// </summary>
        public string Family { get; set; }

        /// <summary>
        /// شماره شناسنامه
        /// </summary>
        public string IdentityNumber { get; set; }


        /// <summary>
        /// کد ملی
        /// </summary>
        public string NationalCode { get; set; }

        /// <summary>
        /// شهر محل تولد
        /// </summary>
        public int? BirthCityId { get; set; }

        /// <summary>
        /// شهر محل صدور شناسنامه
        /// </summary>
        public int? IdentityIssueCityId { get; set; }

        /// <summary>
        /// شماره سریال شناسنامه
        /// </summary>
        public string IdentitySerialNumber { get; set; }

        /// <summary>
        /// تاریخ تولد
        /// </summary>
        public DateTime BirthDate { get; set; }

        /// <summary>
        /// تاریخ صدور شناسنامه
        /// </summary>
        public DateTime IdentityIssueDate { get; set; }

        /// <summary>
        /// کد پرسنلی
        /// </summary>
        public string PersonneliCode { get; set; }

        public int Id { get; set; }


    }
}
