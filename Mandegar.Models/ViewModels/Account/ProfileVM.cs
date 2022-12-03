using Mandegar.Models.Entities.User;
using System;

namespace Mandegar.Models.ViewModels.Account
{
    public class ProfileVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public DateTime? BirthDate { get; set; }
        public string NationalCode { get; set; }
        public string Avatar { get; set; }
        public bool Gender { get; set; }
        public DateTime? LastLogin { get; set; }

        #region Explicit

        public static explicit operator Profile(ProfileVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            return new Profile
            {
                Id = vm.Id,
                Name = vm.Name,
                Family = vm.Family,
                Email = vm.Email,
                Mobile = vm.Mobile,
                BirthDate = vm.BirthDate,
                NationalCode = vm.NationalCode,
                Avatar = vm.Avatar,
                Gender = vm.Gender,
                LastLogin = vm.LastLogin,
            };
        }

        public static explicit operator ProfileVM(Profile entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ProfileVM
            {
                Id = entity.Id,
                Avatar = entity.Avatar,
                BirthDate = entity.BirthDate,
                Email = entity.Email,
                Gender = entity.Gender,
                Family = entity.Family,
                Mobile = entity.Mobile,
                LastLogin = entity.LastLogin,
                Name = entity.Name,
                NationalCode = entity.NationalCode
            };
        }

        #endregion
    }
}
