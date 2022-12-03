using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffFinancials;
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
    public class StaffFinancialService : IStaffFinancialService
    {
        private readonly IUow _uow;

        public StaffFinancialService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Update(StaffFinancial model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            var data = await _uow.GetRepository<StaffFinancial>().Get(c => c.Id == model.Id).FirstOrDefaultAsync();

            if (data == null)
            {
                return new Result<bool>(message: Messages.NotExistsData);
            }

            data.ModifiedById = ClaimHelper.GetUserId();
            data.ModifiedOn = DateTime.Now;

            data.AccountNumber = model.AccountNumber;
            data.BranchName = model.BranchName;
            data.BankId = model.BankId;
            data.Sheba = model.Sheba;

            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<StaffFinancialVM>> Get(int id)
        {
            if (id == 0)
            {
                return new Result<StaffFinancialVM>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<StaffFinancial>().Get(c => c.Id == id).AsNoTracking().FirstOrDefaultAsync();

            return new Result<StaffFinancialVM>((StaffFinancialVM)data);
        }

        public async Task<Result<List<StaffFinancialVM>>> GetAll(int staffId)
        {
            if (staffId == 0)
            {
                return new Result<List<StaffFinancialVM>>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<StaffFinancial>()
                .GetWithInclude(c => c.Bank)
                .Where(c => c.StaffId == staffId)
                .OrderByDescending(c => c.CreatedOn)
                .Select(c => new StaffFinancialVM
                {
                    Id = c.Id,
                    BankId = c.BankId,
                    AccountNumber = c.AccountNumber,
                    Sheba = c.Sheba,
                    BranchName = c.BranchName,
                    BankName = c.Bank.Name
                })
                .AsNoTracking()
                .ToListAsync();

            return new Result<List<StaffFinancialVM>>(data);
        }

        public async Task<Result<bool>> Add(StaffFinancial model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            model.CreatedById = ClaimHelper.GetUserId();
            await _uow.GetRepository<StaffFinancial>().AddAsync(model);
            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<bool>> Delete(int id)
        {
            if (id == 0)
            {
                return new Result<bool>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<StaffFinancial>().Get(c => c.Id == id).FirstOrDefaultAsync();

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

        private (bool success, string message) Validate(StaffFinancial model)
        {
            if (model == null || model.StaffId == 0)
            {
                return (false, Messages.NotExistsData);
            }

            if (model.Sheba?.Length > 26)
            {
                return (false, Messages.InvalidSheba);
            }

            if (model.BankId == 0)
            {
                return (false, Messages.InvalidBank);
            }

            if (string.IsNullOrWhiteSpace(model.AccountNumber) || model.AccountNumber.Length > 20)
            {
                return (false, Messages.InvalidAccountNumber);
            }

            return (true, "");
        }
    }
}
