using Mandegar.Models.ViewModels.Common;

namespace Mandegar.Models.ViewModels.Staffs
{
    public class StaffSearchVM : PageListVM
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string NationalCode { get; set; }
        public bool? Gender { get; set; }
        public string PersonneliCode { get; set; }
        public int? PositionId { get; set; }
        public int? DepartmentId { get; set; }
        public int? CooperationId { get; set; }
    }
}
