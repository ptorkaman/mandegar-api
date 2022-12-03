using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffResumes;
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
    public class ResumeService : IResumeService
    {
        private readonly IUow _uow;

        public ResumeService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Update(Resume model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            var data = await _uow.GetRepository<Resume>().Get(c => c.Id == model.Id).FirstOrDefaultAsync();

            if (data == null)
            {
                return new Result<bool>(message: Messages.NotExistsData);
            }

            data.ModifiedById = ClaimHelper.GetUserId();
            data.ModifiedOn = DateTime.Now;

            data.WorkPlaceName = model.WorkPlaceName;
            data.ActivityDuration = model.ActivityDuration;
            data.AcademicYearId = model.AcademicYearId;
            data.ActivityFieldId = model.ActivityFieldId;
            data.CooperationTypeId = model.CooperationTypeId;
            data.EndDate = model.EndDate;
            data.StartDate = model.StartDate;
            data.WorkExperienceTypeId = model.WorkExperienceTypeId;
            data.PositionId = model.PositionId;

            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<ResumeVM>> Get(int id)
        {
            if (id == 0)
            {
                return new Result<ResumeVM>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<Resume>().Get(c => c.Id == id).FirstOrDefaultAsync();

            return new Result<ResumeVM>((ResumeVM)data);
        }

        public async Task<Result<List<ResumeVM>>> GetAll(int staffId)
        {
            if (staffId == 0)
            {
                return new Result<List<ResumeVM>>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<Resume>()
                .GetWithInclude(c => c.CooperationType,
                                c => c.AcademicYear,
                                c => c.WorkExperienceType,
                                c => c.ActivityField,
                                c => c.Position)
                .Where(c => c.StaffId == staffId)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new ResumeVM
                {
                    Id = c.Id,
                    PositionId = c.PositionId,
                    AcademicYearId = c.AcademicYearId,
                    AcademicYearName = c.AcademicYear.Name,
                    ActivityDuration = c.ActivityDuration,
                    ActivityFieldId = c.ActivityFieldId,
                    ActivityFieldName = c.ActivityField.Name,
                    CooperationTypeId = c.CooperationTypeId,
                    CooperationTypeName = c.CooperationType.Name,
                    EndDate = c.EndDate,
                    PositionName = c.Position.Name,
                    StaffId = staffId,
                    StartDate = c.StartDate,
                    WorkExperienceTypeId = c.WorkExperienceTypeId,
                    WorkExperienceTypeName = c.WorkExperienceType.Name,
                    WorkPlaceName = c.WorkPlaceName,
                })
                .AsNoTracking()
                .ToListAsync();

            return new Result<List<ResumeVM>>(data);
        }

        public async Task<Result<bool>> Add(Resume model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            model.CreatedById = ClaimHelper.GetUserId();
            await _uow.GetRepository<Resume>().AddAsync(model);
            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            if (id == 0)
            {
                return new Result<bool>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<Resume>().Get(c => c.Id == id).FirstOrDefaultAsync();

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

        private (bool success, string message) Validate(Resume model)
        {
            if (model == null || model.StaffId == 0)
            {
                return (false, Messages.NotExistsData);
            }

            if (model.WorkPlaceName?.Length > 100)
            {
                return (false, Messages.InvalidWorkPlaceName);
            }

            if (model.StartDate > model.EndDate)
            {
                return (false, Messages.StartDateCannotGreaterThanEndDate);
            }

            if (model.WorkExperienceTypeId == null || model.WorkExperienceTypeId == 0)
            {
                return (false, Messages.InvalidWorkExperienceType);
            }

            if (model.PositionId == null || model.PositionId == 0)
            {
                return (false, Messages.InvalidPosition);
            }


            return (true, "");
        }
    }
}
