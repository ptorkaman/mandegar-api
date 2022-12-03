using Mandegar.Models.Entities.Personeli;

namespace Mandegar.Models.ViewModels.Sacrifices
{
    public class SacrificeVM
    {
        public int StaffId { get; set; }
        public bool IsMartyrFamily { get; set; }
        public int? RelationId { get; set; }
        public bool IsFreedMan { get; set; }
        public int? CaptivityDuration { get; set; }
        public bool IsVeteran { get; set; }
        public int? VeteranPercentage { get; set; }
        public bool IsSacrificer { get; set; }
        public int? BattlefieldPresenceDuration { get; set; }

        #region explicit

        public static explicit operator SacrificeVM(Sacrifice entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new SacrificeVM
            {
                BattlefieldPresenceDuration = entity.BattlefieldPresenceDuration,
                CaptivityDuration = entity.CaptivityDuration,
                IsFreedMan = entity.IsFreedMan,
                IsVeteran = entity.IsVeteran,
                VeteranPercentage = entity.VeteranPercentage,
                IsMartyrFamily = entity.IsMartyrFamily,
                IsSacrificer = entity.IsSacrificer,
                RelationId = entity.RelationId,
                StaffId = entity.StaffId
            };
        }

        public static explicit operator Sacrifice(SacrificeVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            return new Sacrifice
            {
                BattlefieldPresenceDuration = vm.BattlefieldPresenceDuration,
                CaptivityDuration = vm.CaptivityDuration,
                IsFreedMan = vm.IsFreedMan,
                IsVeteran = vm.IsVeteran,
                VeteranPercentage = vm.VeteranPercentage,
                IsMartyrFamily = vm.IsMartyrFamily,
                IsSacrificer = vm.IsSacrificer,
                RelationId = vm.RelationId,
                StaffId = vm.StaffId
            };
        }

        #endregion
    }
}
