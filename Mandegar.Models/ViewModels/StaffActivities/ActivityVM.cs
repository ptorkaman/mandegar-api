using Mandegar.Models.Entities.Personeli;
using System;

namespace Mandegar.Models.ViewModels.StaffActivities
{
    public class ActivityVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Subject { get; set; }
        public string PublicationName { get; set; }
        public DateTime PublicationDate { get; set; }
        public int StaffId { get; set; }
        public int ActivityTypeId { get; set; }
        public int ActivityCaseId { get; set; }

        public string ActivityTypeName { get; set; }
        public string ActivityCaseName { get; set; }

        #region explicit

        public static explicit operator ActivityVM(Activity entity)
        {
            if (entity == null)
            {
                return null;
            }

            return new ActivityVM
            {
                ActivityCaseId = entity.ActivityCaseId,
                ActivityTypeId = entity.ActivityTypeId,
                Id = entity.Id,
                Name = entity.Name,
                Subject = entity.Subject,
                PublicationDate = entity.PublicationDate,
                StaffId = entity.StaffId,
                PublicationName = entity.PublicationName,
            };
        }

        public static explicit operator Activity(ActivityVM vm)
        {
            if (vm == null)
            {
                return null;
            }

            return new Activity
            {
                ActivityCaseId = vm.ActivityCaseId,
                ActivityTypeId = vm.ActivityTypeId,
                Id = vm.Id,
                Name = vm.Name,
                Subject = vm.Subject,
                PublicationDate = vm.PublicationDate,
                StaffId = vm.StaffId,
                PublicationName = vm.PublicationName,
            };

        }

        #endregion
    }
}
