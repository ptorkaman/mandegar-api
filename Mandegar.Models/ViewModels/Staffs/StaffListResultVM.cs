using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.ViewModels.BaseInfo;
using Mandegar.Models.ViewModels.Common;
using System;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.Staffs
{
    public class StaffListResultVM
    {
        public int Id { get; set; }
        public string Image { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string FullName => Name + " " + Family;
        public string NationalCode { get; set; }
        public string PersonneliCode { get; set; }
        public string PositionName { get; set; }
        public string CooperationTypeName { get; set; }
        public DateTime? CooperationEndDate { get; set; }
        public bool Status { get; set; }
        public ICollection<AssignPosition> AssignPositions { get; set; }
        public Staff Staff { get; set; }
        public List<Position> Positions { get; set; }
        public Root Root { get; set; }
        public string PositionTitle { get; set; }
    }
}
