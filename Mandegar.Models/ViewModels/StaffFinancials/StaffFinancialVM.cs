using Mandegar.Models.Entities.Personeli;

namespace Mandegar.Models.ViewModels.StaffFinancials
{
    public class StaffFinancialVM
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int BankId { get; set; }
        public string AccountNumber { get; set; }
        public string Sheba { get; set; }
        public string BranchName { get; set; }
        public string BankName { get; set; }

        #region explicit

        public static explicit operator StaffFinancial(StaffFinancialVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            return new StaffFinancial
            {
                Id = vm.Id,
                AccountNumber = vm.AccountNumber,
                BankId = vm.BankId,
                Sheba = vm.Sheba,
                BranchName = vm.BranchName,
                StaffId = vm.StaffId,
            };
        }

        public static explicit operator StaffFinancialVM(StaffFinancial entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new StaffFinancialVM
            {
                Id = entity.Id,
                AccountNumber = entity.AccountNumber,
                BankId = entity.BankId,
                Sheba = entity.Sheba,
                BranchName = entity.BranchName,
                StaffId = entity.StaffId,
            };
        }

        #endregion
    }
}
