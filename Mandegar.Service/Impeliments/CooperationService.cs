using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Cooperations;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class CooperationService : ICooperationService
    {
        private readonly IUow _uow;

        public CooperationService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Update(Cooperation model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            var data = await _uow.GetRepository<Cooperation>().Get(c => c.StaffId == model.StaffId).FirstOrDefaultAsync();

            if (data == null)
            {
                model.CreatedById = ClaimHelper.GetUserId();

                await _uow.GetRepository<Cooperation>().AddAsync(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }

            data.ModifiedById = ClaimHelper.GetUserId();
            data.ModifiedOn = DateTime.Now;

            data.CooperationStartDate = model.CooperationStartDate;
            data.CooperationEndDate = model.CooperationEndDate;
            data.CooperationTypeId = model.CooperationTypeId;
            data.DepartmentId = model.DepartmentId;
            data.IsActive = model.IsActive;

            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<CooperationVM>> Get(int staffId)
        {
            if (staffId == 0)
            {
                return new Result<CooperationVM>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<Cooperation>().Get(c => c.StaffId == staffId).FirstOrDefaultAsync();

            return new Result<CooperationVM>((CooperationVM)data);
        }

        private (bool success, string message) Validate(Cooperation model)
        {
            if (model == null)
            {
                return (false, Messages.NotExistsData);
            }

            if (model.CooperationTypeId == 0)
            {
                return (false, Messages.InvalidCooperationType);
            }

            if (model.DepartmentId == 0)
            {
                return (false, Messages.InvalidDepartment);
            }


            return (true, "");
        }
    }
}
