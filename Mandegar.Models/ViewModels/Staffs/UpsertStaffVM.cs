using Mandegar.Models.Entities.Personeli;
using System;

namespace Mandegar.Models.ViewModels.Staffs
{
    public class UpsertStaffVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string IdentityNumber { get; set; }
        public string NationalCode { get; set; }
        public int? BirthCityId { get; set; }
        public int? IdentityIssueCityId { get; set; }
        public string IdentitySerialNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public DateTime? IdentityIssueDate { get; set; }
        public string PersonneliCode { get; set; }
        public string Image { get; set; }
        public bool Gender { get; set; }
        public string FatherName { get; set; }
        public bool IsActive { get; set; }

        #region Explicit

        public static explicit operator Staff(UpsertStaffVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            return new Staff
            {
                Id = vm.Id,
                Name = vm.Name,
                Family = vm.Family,
                IdentityNumber = vm.IdentityNumber,
                BirthCityId = vm.BirthCityId,
                NationalCode = vm.NationalCode,
                IdentityIssueCityId = vm.IdentityIssueCityId,
                BirthDate = vm.BirthDate,
                IdentityIssueDate = vm.IdentityIssueDate,
                PersonneliCode = vm.PersonneliCode,
                Image = vm.Image,
                Gender = vm.Gender,
                FatherName = vm.FatherName,
                IsActive = vm.IsActive
            };

        }

        public static explicit operator UpsertStaffVM(Staff entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new UpsertStaffVM
            {
                Id = entity.Id,
                Name = entity.Name,
                Family = entity.Family,
                IdentityNumber = entity.IdentityNumber,
                BirthCityId = entity.BirthCityId,
                NationalCode = entity.NationalCode,
                IdentityIssueCityId = entity.IdentityIssueCityId,
                BirthDate = entity.BirthDate,
                IdentityIssueDate = entity.IdentityIssueDate,
                PersonneliCode = entity.PersonneliCode,
                Image = entity.Image,
                Gender = entity.Gender,
                FatherName = entity.FatherName,
                IsActive = entity.IsActive
            };

        }
        #endregion
    }
}
