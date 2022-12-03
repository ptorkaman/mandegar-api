using System;

namespace Mandegar.Models.ViewModels.Account
{
    public class TokenVM
    {
        public string Token { get; set; }
        public DateTime? ExpireTime { get; set; }
    }
}
