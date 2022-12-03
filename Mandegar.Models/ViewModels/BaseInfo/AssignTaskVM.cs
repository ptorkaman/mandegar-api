using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.BaseInfo
{
    public class AssignTaskVM
    {
        public int Id { get; set; }
        public int PositionId { get; set; }

        public int TaskId { get; set; }
        public int TaskGroupId { get; set; }
        
        public string TaskName { get; set; }
        public string PositionName { get; set; }
        public Tasks Task { get; set; }
        public List<TaskVM> SelectTaskList { get; set; }
        public string Name { get; set; }
    }
}
