using Mandegar.Models.ViewModels.Roles;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.Account
{
    public class UpdateUserVM
    {
        public UpdateUserVM()
        {
            Roles = new List<RoleVM>();
        }
        public UserVM User { get; set; }
        public ProfileVM Profile { get; set; }
        public List<RoleVM> Roles { get; set; }
        public string UserAvatar { get; set; }
    }
}
