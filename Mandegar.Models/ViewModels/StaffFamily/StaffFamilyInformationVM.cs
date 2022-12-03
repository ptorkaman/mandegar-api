using Mandegar.Models.Entities.Personeli;
using System;

namespace Mandegar.Models.ViewModels.StaffFamily
{
    public class StaffFamilyInformationVM
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string IdentityNumber { get; set; }
        public string NationalCode { get; set; }
        public DateTime? BirthDate { get; set; }
        public int RelationId { get; set; }
        public int? EducationId { get; set; }
        public string StudyField { get; set; }
        public int? MaritalStatusId { get; set; }
        public string Job { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string WorkAddress { get; set; }
        public string WorkPhone { get; set; }
        public string Email { get; set; }
        public string Description { get; set; }

        public string RelationName { get; set; }

        #region explicit

        public static explicit operator StaffFamilyInformationVM(StaffFamilyInformation entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new StaffFamilyInformationVM
            {
                Id = entity.Id,
                StaffId = entity.StaffId,
                BirthDate = entity.BirthDate,
                RelationId = entity.RelationId,
                EducationId = entity.EducationId,
                StudyField = entity.StudyField,
                MaritalStatusId = entity.MaritalStatusId,
                Job = entity.Job,
                Phone = entity.Phone,
                Email = entity.Email,
                Description = entity.Description,
                Family = entity.Family,
                IdentityNumber = entity.IdentityNumber,
                Mobile = entity.Mobile,
                Name = entity.Name,
                NationalCode = entity.NationalCode,
                WorkAddress = entity.WorkAddress,
                WorkPhone = entity.WorkPhone,
            };

        }

        public static explicit operator StaffFamilyInformation(StaffFamilyInformationVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            return new StaffFamilyInformation
            {
                Id = vm.Id,
                StaffId = vm.StaffId,
                BirthDate = vm.BirthDate,
                RelationId = vm.RelationId,
                EducationId = vm.EducationId,
                StudyField = vm.StudyField,
                MaritalStatusId = vm.MaritalStatusId,
                Job = vm.Job,
                Phone = vm.Phone,
                Email = vm.Email,
                Description = vm.Description,
                Family = vm.Family,
                IdentityNumber = vm.IdentityNumber,
                Mobile = vm.Mobile,
                Name = vm.Name,
                NationalCode = vm.NationalCode,
                WorkAddress = vm.WorkAddress,
                WorkPhone = vm.WorkPhone,
            };

        }

        #endregion
    }
}
