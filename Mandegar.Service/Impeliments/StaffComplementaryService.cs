using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffComplementaries;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class StaffComplementaryService : IStaffComplementaryService
    {
        private readonly IUow _uow;

        public StaffComplementaryService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Update(StaffComplementary model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            var data = await _uow.GetRepository<StaffComplementary>().Get(c => c.StaffId == model.StaffId).FirstOrDefaultAsync();

            if (data == null)
            {
                model.CreatedById = ClaimHelper.GetUserId();

                await _uow.GetRepository<StaffComplementary>().AddAsync(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }

            data.ModifiedById = ClaimHelper.GetUserId();
            data.ModifiedOn = DateTime.Now;

            data.BloodTypeId = model.BloodTypeId;
            data.CertificateNumber = model.CertificateNumber;
            data.InsuranceNumber = model.InsuranceNumber;
            data.InsuranceTypeId = model.InsuranceTypeId;
            data.MaritalStatusId = model.MaritalStatusId;
            data.MilitaryServiceStatusId = model.MilitaryServiceStatusId;
            data.NationalityId = model.NationalityId;
            data.ReligionId = model.ReligionId;
            data.MilitaryServiceDate = model.MilitaryServiceDate;

            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<StaffComplementaryVM>> Get(int staffId)
        {
            if (staffId == 0)
            {
                return new Result<StaffComplementaryVM>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<StaffComplementary>().Get(c => c.StaffId == staffId).AsNoTracking().FirstOrDefaultAsync();

            return new Result<StaffComplementaryVM>((StaffComplementaryVM)data);
        }

        private (bool success, string message) Validate(StaffComplementary model)
        {
            if (model == null)
            {
                return (false, Messages.NotExistsData);
            }

            if (model.ReligionId == 0 || model.ReligionId == null)
            {
                return (false, Messages.InvalidReligion);
            }

            if (model.MaritalStatusId == 0 || model.MaritalStatusId == null)
            {
                return (false, Messages.InvalidMaritalStatus);
            }

            if (model.MilitaryServiceStatusId == 0 || model.MilitaryServiceStatusId == null)
            {
                return (false, Messages.InvalidMilitaryServiceStatus);
            }

            if (model.InsuranceTypeId == 0 || model.InsuranceTypeId == null)
            {
                return (false, Messages.InvalidInsuranceType);
            }

            if (string.IsNullOrWhiteSpace(model.InsuranceNumber) || model?.InsuranceNumber.Length > 10)
            {
                return (false, Messages.InvalidInsuranceNumber);
            }

            return (true, "");
        }
    }
}
