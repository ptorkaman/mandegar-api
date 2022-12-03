using Mandegar.Models.Entities.Personeli;
using System;

namespace Mandegar.Models.ViewModels.EducationalQualifications
{
    public class EducationalQualificationVM
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int EducationId { get; set; }
        public int DocumentId { get; set; }
        public string CourseName { get; set; }
        public DateTime? StartDate { get; set; }
        public int Period { get; set; }
        public string InstitutionName { get; set; }
        public DateTime? DegreeReceiptDate { get; set; }

        public string EducationName { get; set; }

        #region exlicit

        public static explicit operator EducationalQualificationVM(EducationalQualification entity)
        {
            if (entity == null)
            {
                return null;
            }
            return new EducationalQualificationVM
            {
                Id = entity.Id,
                CourseName = entity.CourseName,
                DegreeReceiptDate = entity.DegreeReceiptDate,
                DocumentId = entity.DocumentId,
                EducationId = entity.EducationId,
                InstitutionName = entity.InstitutionName,
                Period = entity.Period,
                StaffId = entity.StaffId,
                StartDate = entity.StartDate
            };
        }

        public static explicit operator EducationalQualification(EducationalQualificationVM vm)
        {
            if (vm == null)
            {
                return null;
            }
            return new EducationalQualification
            {
                Id = vm.Id,
                CourseName = vm.CourseName,
                DegreeReceiptDate = vm.DegreeReceiptDate,
                DocumentId = vm.DocumentId,
                EducationId = vm.EducationId,
                InstitutionName = vm.InstitutionName,
                Period = vm.Period,
                StaffId = vm.StaffId,
                StartDate = vm.StartDate
            };
        }


        #endregion
    }
}
