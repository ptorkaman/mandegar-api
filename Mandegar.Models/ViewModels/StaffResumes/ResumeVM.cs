using Mandegar.Models.Entities.Personeli;
using System;

namespace Mandegar.Models.ViewModels.StaffResumes
{
    public class ResumeVM
    {
        public int Id { get; set; }
        public int StaffId { get; set; }
        public int? WorkExperienceTypeId { get; set; }
        public int? AcademicYearId { get; set; }
        public int? CooperationTypeId { get; set; }
        public int? ActivityFieldId { get; set; }
        public int? PositionId { get; set; }
        public string WorkPlaceName { get; set; }
        public int? ActivityDuration { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public string WorkExperienceTypeName { get; set; }
        public string AcademicYearName { get; set; }
        public string CooperationTypeName{ get; set; }
        public string ActivityFieldName { get; set; }
        public string PositionName { get; set; }


        #region explicit

        public static explicit operator Resume(ResumeVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            return new Resume
            {
                AcademicYearId = vm.AcademicYearId,
                ActivityDuration = vm.ActivityDuration,
                ActivityFieldId = vm.ActivityFieldId,
                CooperationTypeId = vm.CooperationTypeId,
                EndDate = vm.EndDate,
                Id = vm.Id,
                StaffId = vm.StaffId,
                StartDate = vm.StartDate,
                WorkExperienceTypeId = vm.WorkExperienceTypeId,
                WorkPlaceName = vm.WorkPlaceName,
                PositionId = vm.PositionId
            };
        }

        public static explicit operator ResumeVM(Resume entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ResumeVM
            {
                AcademicYearId = entity.AcademicYearId,
                ActivityDuration = entity.ActivityDuration,
                ActivityFieldId = entity.ActivityFieldId,
                CooperationTypeId = entity.CooperationTypeId,
                EndDate = entity.EndDate,
                Id = entity.Id,
                StaffId = entity.StaffId,
                StartDate = entity.StartDate,
                WorkExperienceTypeId = entity.WorkExperienceTypeId,
                WorkPlaceName = entity.WorkPlaceName,
                PositionId = entity.PositionId
            };
        }

        #endregion
    }
}
