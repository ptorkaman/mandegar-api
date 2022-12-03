using Mandegar.Models.ViewModels.Common;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.Staffs
{
    public class AssignPositionVM 
    {
        public int PositionId { get; set; }


        public int StaffId { get; set; }
        public string PositionName { get; set; }
        public string StuffName { get; set; }
        public IList<int> Positions { get; set; }
    }
}
