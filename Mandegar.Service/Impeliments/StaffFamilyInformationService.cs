using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffFamily;
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
    public class StaffFamilyInformationService : IStaffFamilyInformationService
    {
        private readonly IUow _uow;

        public StaffFamilyInformationService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Update(StaffFamilyInformation model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            var data = await _uow.GetRepository<StaffFamilyInformation>().Get(c => c.Id == model.Id).FirstOrDefaultAsync();

            if (data == null)
            {
                return new Result<bool>(message: Messages.NotExistsData);
            }

            var isExistsByNationalCode = await _uow.GetRepository<StaffFamilyInformation>().Get(c => c.NationalCode == model.NationalCode && c.Id != model.Id).AnyAsync();
            if (isExistsByNationalCode)
            {
                return new Result<bool>(Messages.DuplicateNationalCode);
            }

            data.ModifiedById = ClaimHelper.GetUserId();
            data.ModifiedOn = DateTime.Now;

            data.BirthDate = model.BirthDate;
            data.WorkPhone = model.WorkPhone;
            data.WorkAddress = model.WorkAddress;
            data.IdentityNumber = model.IdentityNumber;
            data.MaritalStatusId = model.MaritalStatusId;
            data.Job = model.Job;
            data.Description = model.Description;
            data.Name = model.Name;
            data.Phone = model.Phone;
            data.EducationId = model.EducationId;
            data.Email = model.Email;
            data.Family = model.Family;
            data.StudyField = model.StudyField;
            data.RelationId = model.RelationId;
            data.Mobile = model.Mobile;
            data.NationalCode = model.NationalCode;


            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<StaffFamilyInformationVM>> Get(int id)
        {
            if (id == 0)
            {
                return new Result<StaffFamilyInformationVM>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<StaffFamilyInformation>().Get(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return new Result<StaffFamilyInformationVM>((StaffFamilyInformationVM)data);
        }

        public async Task<Result<List<StaffFamilyInformationVM>>> GetAll(int staffId)
        {
            if (staffId == 0)
            {
                return new Result<List<StaffFamilyInformationVM>>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<StaffFamilyInformation>()
                .GetWithInclude(c => c.Relation)
                .Where(c => c.StaffId == staffId)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new StaffFamilyInformationVM
                {
                    Name = c.Name,
                    NationalCode = c.NationalCode,
                    Family = c.Family,
                    RelationId = c.RelationId,
                    RelationName = c.Relation.Name,
                    Phone = c.Phone,
                    Mobile = c.Mobile,
                    StaffId = c.StaffId,
                    Id = c.Id
                })
                .AsNoTracking()
                .ToListAsync();

            return new Result<List<StaffFamilyInformationVM>>(data);
        }

        public async Task<Result<bool>> Add(StaffFamilyInformation model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            var isExistsByNationalCode = await _uow.GetRepository<StaffFamilyInformation>().Get(c => c.NationalCode == model.NationalCode).AnyAsync();
            if (isExistsByNationalCode)
            {
                return new Result<bool>(Messages.DuplicateNationalCode);
            }

            model.CreatedById = ClaimHelper.GetUserId();
            await _uow.GetRepository<StaffFamilyInformation>().AddAsync(model);
            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            if (id == 0)
            {
                return new Result<bool>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<StaffFamilyInformation>().Get(c => c.Id == id).FirstOrDefaultAsync();

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

        private (bool success, string message) Validate(StaffFamilyInformation model)
        {
            if (model == null || model.StaffId == 0)
            {
                return (false, Messages.NotExistsData);
            }

            if (string.IsNullOrWhiteSpace(model.Name) || model.Name?.Length > 32)
            {
                return (false, Messages.InvalidName);
            }

            if (string.IsNullOrWhiteSpace(model.Family) || model.Family?.Length > 32)
            {
                return (false, Messages.InvalidName);
            }

            if (string.IsNullOrWhiteSpace(model.NationalCode) ||
                model.NationalCode?.Length != 10 ||
                 Validations.IsValidNationaCode(model?.NationalCode) == false)
            {
                return (false, Messages.InvalidNationalCode);
            }

            if (string.IsNullOrWhiteSpace(model.Phone) || model.Phone?.Length > 11)
            {
                return (false, Messages.InvalidPhone);
            }

            if (string.IsNullOrWhiteSpace(model.Mobile) || model.Mobile?.Length > 11)
            {
                return (false, Messages.InvalidMobile);
            }


            return (true, "");
        }
    }
}
