using Mandegar.Models.Entities.User;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.Roles;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.Account
{
    public class CreateRoleVM
    {
        public CreateRoleVM()
        {
            Root = new Root();
        }
        public List<PermissionVM> Permissions { get; set; }
        public Role Role { get; set; }
        public Root Root { get; set; }
    }
}
