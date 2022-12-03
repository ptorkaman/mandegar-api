using Mandegar.Models.Entities.User;
using System;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.Account
{
    public class AdminUserListVM
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public DateTime? LastLogin { get; set; }
        public bool IsActive { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string DeleterUserName { get; set; }
        public ICollection<UserRole> UserRoles { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string RoleNames { get; set; }
    }
}
