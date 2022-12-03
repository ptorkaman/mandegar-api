using Mandegar.Models.Entities.Personeli;
using System;

namespace Mandegar.Models.ViewModels.Cooperations
{
    public class CooperationVM
    {
        public int StaffId { get; set; }
        public int CooperationTypeId { get; set; }
        public int DepartmentId { get; set; }
        public DateTime? CooperationStartDate { get; set; }
        public DateTime? CooperationEndDate { get; set; }
        public bool IsActive { get; set; }

        #region explicit

        public static explicit operator CooperationVM(Cooperation entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new CooperationVM
            {
                CooperationEndDate = entity.CooperationEndDate,
                CooperationStartDate = entity.CooperationStartDate,
                CooperationTypeId = entity.CooperationTypeId,
                DepartmentId = entity.DepartmentId,
                StaffId = entity.StaffId,
                IsActive = entity.IsActive
            };
        }

        public static explicit operator Cooperation(CooperationVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            return new Cooperation
            {
                CooperationEndDate = vm.CooperationEndDate,
                CooperationStartDate = vm.CooperationStartDate,
                CooperationTypeId = vm.CooperationTypeId,
                DepartmentId = vm.DepartmentId,
                StaffId = vm.StaffId,
                IsActive = vm.IsActive
            };
        }

        #endregion
    }
}
