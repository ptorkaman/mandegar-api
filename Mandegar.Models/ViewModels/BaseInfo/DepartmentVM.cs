using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class DepartmentVM
    {
        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        public int Id { get; set; }
        public int? ParentId { get; set; }

        public string ParentName { get; set; }

    }
}
