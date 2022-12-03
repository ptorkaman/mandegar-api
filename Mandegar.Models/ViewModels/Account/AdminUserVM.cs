using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.Account
{
    public class AdminUserVM
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Avatar { get; set; }
        public int PermissionId { get; set; }
        public string PermissionName { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsActivePermission { get; set; }
    }
}
