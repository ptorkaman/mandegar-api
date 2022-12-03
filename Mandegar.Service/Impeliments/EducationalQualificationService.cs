using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.EducationalQualifications;
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
    public class EducationalQualificationService : IEducationalQualificationService
    {
        private readonly IUow _uow;

        public EducationalQualificationService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Update(EducationalQualification model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            var data = await _uow.GetRepository<EducationalQualification>().Get(c => c.Id == model.Id).FirstOrDefaultAsync();

            if (data == null)
            {
                return new Result<bool>(message: Messages.NotExistsData);
            }

            data.ModifiedById = ClaimHelper.GetUserId();
            data.ModifiedOn = DateTime.Now;



            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<EducationalQualificationVM>> Get(int id)
        {
            if (id == 0)
            {
                return new Result<EducationalQualificationVM>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<EducationalQualification>().Get(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return new Result<EducationalQualificationVM>((EducationalQualificationVM)data);
        }

        public async Task<Result<List<EducationalQualificationVM>>> GetAll(int staffId)
        {
            if (staffId == 0)
            {
                return new Result<List<EducationalQualificationVM>>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<EducationalQualification>()
                .GetWithInclude(c => c.Education)
                .Where(c => c.StaffId == staffId)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new EducationalQualificationVM
                {
                    Id = c.Id,
                    CourseName = c.CourseName,
                    InstitutionName = c.InstitutionName,
                    EducationName = c.Education.Name
                })
                .AsNoTracking()
                .ToListAsync();

            return new Result<List<EducationalQualificationVM>>(data);
        }

        public async Task<Result<bool>> Add(EducationalQualification model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            model.CreatedById = ClaimHelper.GetUserId();
            await _uow.GetRepository<EducationalQualification>().AddAsync(model);
            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            if (id == 0)
            {
                return new Result<bool>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<EducationalQualification>().Get(c => c.Id == id).FirstOrDefaultAsync();

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

        private (bool success, string message) Validate(EducationalQualification model)
        {
            if (model == null || model.StaffId == 0)
            {
                return (false, Messages.NotExistsData);
            }

            return (true, "");
        }
    }
}
