using Mandegar.Models.Entities.User;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.Roles
{
    public class RoleVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool ShowInList { get; set; }
        public bool IsActive { get; set; }
        public List<int> Permissions { get; set; }


        #region Explicit

        public static explicit operator Role(RoleVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            var role = new Role
            {
                Id = vm.Id,
                Name = vm.Name,
                ShowInList = vm.ShowInList,
                IsActive = vm.IsActive,
                RolePermissions = new List<RolePermission>()
            };

            foreach (var item in vm.Permissions)
            {
                role.RolePermissions.Add(
                    new Entities.User.RolePermission
                    {
                        RoleId = vm.Id,
                        PermissionId = item
                    });
            }

            return role;
        }

        public static explicit operator RoleVM(Role entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new RoleVM
            {
                Id = entity.Id,
                IsActive = entity.IsActive,
                Name = entity.Name,
                ShowInList = entity.ShowInList,
            };
        }

        #endregion
    }
}
