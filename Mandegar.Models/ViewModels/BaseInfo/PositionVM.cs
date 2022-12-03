using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class PositionVM
    {
        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }
        public string ParentName { get; set; }

        public int Id { get; set; }
        public int? ParentId { get; set; }


    }
}
