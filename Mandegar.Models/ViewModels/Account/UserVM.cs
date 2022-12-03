using Mandegar.Models.Entities.User;

namespace Mandegar.Models.ViewModels.Account
{
    public class UserVM
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool IsActive { get; set; }

        #region Explicit

        public static explicit operator User(UserVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            return new User
            {
                Id = vm.Id,
                Username = vm.Username,
                IsActive = vm.IsActive
            };
        }

        public static explicit operator UserVM(User entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new UserVM
            {
                Id = entity.Id,
                Username = entity.Username,
                IsActive = entity.IsActive
            };
        }

        #endregion
    }
}
