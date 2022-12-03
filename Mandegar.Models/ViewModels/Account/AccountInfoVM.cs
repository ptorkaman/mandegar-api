using System;

namespace Mandegar.Models.ViewModels.Account
{
    public class AccountInfoVM
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Username { get; set; }
        public DateTime RegisterDate { get; set; }
        public decimal WalletAmount { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
        public int WalletId { get; set; }
    }
}
