using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class DepartmentMemberVM
    {
        /// <summary>
        /// کد دپارتمان
        /// </summary>
        public int DepartmentId { get; set; }

        /// <summary>
        /// کد پرسنل
        /// </summary>
        public int StaffId { get; set; }

        /// <summary>
        /// کد سمت
        /// </summary>
        public int PositionId { get; set; }

        public int Id { get; set; }
        public string DepartmentName { get; set; }
        public string PositionName { get; set; }
        public string StaffName { get; set; }
    }
}
