using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffActivities;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class ActivityService : IActivityService
    {
        private readonly IUow _uow;

        public ActivityService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Update(Activity model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            var data = await _uow.GetRepository<Activity>().Get(c => c.Id == model.Id).FirstOrDefaultAsync();

            if (data == null)
            {
                return new Result<bool>(message: Messages.NotExistsData);
            }

            data.ModifiedById = ClaimHelper.GetUserId();
            data.ModifiedOn = DateTime.Now;

            data.ActivityCaseId = model.ActivityCaseId;
            data.ActivityTypeId = model.ActivityTypeId;
            data.Name = model.Name;
            data.PublicationDate = model.PublicationDate;
            data.PublicationName = model.PublicationName;
            data.Subject = model.Subject;

            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<ActivityVM>> Get(int id)
        {
            if (id == 0)
            {
                return new Result<ActivityVM>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<Activity>().Get(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return new Result<ActivityVM>((ActivityVM)data);
        }

        public async Task<Result<List<ActivityVM>>> GetAll(int staffId)
        {
            if (staffId == 0)
            {
                return new Result<List<ActivityVM>>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<Activity>()
                .GetWithInclude(c => c.ActivityType,
                                c => c.ActivityCase)
                .Where(c => c.StaffId == staffId)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new ActivityVM
                {
                    Id = c.Id,
                    ActivityCaseId = c.ActivityCaseId,
                    Subject = c.Subject,
                    PublicationName = c.PublicationName,
                    PublicationDate = c.PublicationDate,
                    ActivityTypeId = c.ActivityTypeId,
                    Name = c.Name,
                    ActivityTypeName = c.ActivityType.Name,
                    ActivityCaseName = c.ActivityCase.Name
                })
                .AsNoTracking()
                .ToListAsync();

            return new Result<List<ActivityVM>>(data);
        }

        public async Task<Result<bool>> Add(Activity model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            model.CreatedById = ClaimHelper.GetUserId();
            await _uow.GetRepository<Activity>().AddAsync(model);
            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            if (id == 0)
            {
                return new Result<bool>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<Activity>().Get(c => c.Id == id).FirstOrDefaultAsync();

            if (data == null)
            {
                return new Result<bool>(message: Messages.NotExistsData);
            }

            data.IsDeleted = true;
            data.ModifiedById = ClaimHelper.GetUserId();
            data.ModifiedOn = DateTime.Now;

            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        private (bool success, string message) Validate(Activity model)
        {
            if (model == null || model.StaffId == 0)
            {
                return (false, Messages.NotExistsData);
            }

            if (model.ActivityTypeId == 0)
            {
                return (false, Messages.InvalidActivityType);
            }

            if (model.ActivityCaseId == 0)
            {
                return (false, Messages.InvalidActivityCase);
            }

            return (true, "");
        }
    }
}
