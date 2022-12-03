using Mandegar.Models.Entities.Personeli;
using System;

namespace Mandegar.Models.ViewModels.StaffComplementaries
{
    public class StaffComplementaryVM
    {
        public int StaffId { get; set; }
        public string CertificateNumber { get; set; }
        public int? ReligionId { get; set; }
        public int? NationalityId { get; set; }
        public int? BloodTypeId { get; set; }
        public int? MaritalStatusId { get; set; }
        public int? MilitaryServiceStatusId { get; set; }
        public DateTime? MilitaryServiceDate { get; set; }
        public int? InsuranceTypeId { get; set; }
        public string InsuranceNumber { get; set; }
        public string IdentitySerialNumber { get; set; }


        #region explicit

        public static explicit operator StaffComplementary(StaffComplementaryVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            return new StaffComplementary
            {
                BloodTypeId = vm.BloodTypeId,
                CertificateNumber = vm.CertificateNumber,
                InsuranceNumber = vm.InsuranceNumber,
                MilitaryServiceStatusId = vm.MilitaryServiceStatusId,
                InsuranceTypeId = vm.InsuranceTypeId,
                NationalityId = vm.NationalityId,
                MaritalStatusId = vm.MaritalStatusId,
                MilitaryServiceDate = vm.MilitaryServiceDate,
                ReligionId = vm.ReligionId,
                StaffId = vm.StaffId,
                IdentitySerialNumber = vm.IdentitySerialNumber,

            };
        }

        public static explicit operator StaffComplementaryVM(StaffComplementary entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new StaffComplementaryVM
            {
                BloodTypeId = entity.BloodTypeId,
                CertificateNumber = entity.CertificateNumber,
                InsuranceNumber = entity.InsuranceNumber,
                MilitaryServiceStatusId = entity.MilitaryServiceStatusId,
                InsuranceTypeId = entity.InsuranceTypeId,
                NationalityId = entity.NationalityId,
                MaritalStatusId = entity.MaritalStatusId,
                MilitaryServiceDate = entity.MilitaryServiceDate,
                ReligionId = entity.ReligionId,
                StaffId = entity.StaffId,
                IdentitySerialNumber = entity.IdentitySerialNumber,
            };
        }

        #endregion
    }
}
