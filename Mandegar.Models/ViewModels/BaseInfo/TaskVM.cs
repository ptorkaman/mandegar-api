using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class TaskVM
    {
        /// <summary>
        /// عنوان
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// شناسه گروه وظیفه
        /// </summary>
        public int TaskGroupId { get; set; }

        public string TaskGroupName { get; set; }

        public int Id { get; set; }
    }
}
