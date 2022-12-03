using Mandegar.Models.ViewModels.Common;

namespace Mandegar.Models.ViewModels.Account
{
    public class UserSearchVM : PageListVM
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
    }
}
