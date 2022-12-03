using Mandegar.Models.Entities.User;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;

namespace Mandegar.Models.ViewModels.Account
{
    public class CreateUserVM
    {
        public CreateUserVM()
        {
            Roles = new List<Role>();
        }
        public User User { get; set; }
        public Profile Profile { get; set; }
        public List<Role> Roles { get; set; }
        public string UserAvatar { get; set; }
    }
}
