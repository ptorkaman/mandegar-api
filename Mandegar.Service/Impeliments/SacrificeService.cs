using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Sacrifices;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class SacrificeService : ISacrificeService
    {
        private readonly IUow _uow;

        public SacrificeService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Update(Sacrifice model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            var data = await _uow.GetRepository<Sacrifice>().Get(c => c.StaffId == model.StaffId).FirstOrDefaultAsync();

            if (data == null)
            {
                model.CreatedById = ClaimHelper.GetUserId();

                await _uow.GetRepository<Sacrifice>().AddAsync(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }

            data.ModifiedById = ClaimHelper.GetUserId();
            data.ModifiedOn = DateTime.Now;

            if (!model.IsMartyrFamily)
            {
                model.RelationId = null;
            }
            if (!model.IsFreedMan)
            {
                model.CaptivityDuration = null;
            }
            if (!model.IsVeteran)
            {
                model.VeteranPercentage = null;
            }
            if (!model.IsSacrificer)
            {
                model.BattlefieldPresenceDuration = null;
            }

            data.BattlefieldPresenceDuration = model.BattlefieldPresenceDuration;
            data.CaptivityDuration = model.CaptivityDuration;
            data.IsMartyrFamily = model.IsMartyrFamily;
            data.IsFreedMan = model.IsFreedMan;
            data.IsSacrificer = model.IsSacrificer;
            data.IsVeteran = model.IsVeteran;
            data.RelationId = model.RelationId;
            data.VeteranPercentage = model.VeteranPercentage;


            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<SacrificeVM>> Get(int staffId)
        {
            if (staffId == 0)
            {
                return new Result<SacrificeVM>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<Sacrifice>().Get(c => c.StaffId == staffId).FirstOrDefaultAsync();

            return new Result<SacrificeVM>((SacrificeVM)data);
        }

        private (bool success, string message) Validate(Sacrifice model)
        {
            if (model == null)
            {
                return (false, Messages.NotExistsData);
            }

            if (model.IsFreedMan && (model.CaptivityDuration == null || model.CaptivityDuration == 0))
            {
                return (false, Messages.InvalidCaptivityDuration);
            }

            if (model.IsMartyrFamily && model.RelationId == null)
            {
                return (false, Messages.ExistrelationItem);
            }

            if (model.IsVeteran && (model.VeteranPercentage == null || model.VeteranPercentage == 0))
            {
                return (false, Messages.InvalidVeteranPercentage);
            }

            if (model.IsSacrificer && (model.BattlefieldPresenceDuration == null || model.BattlefieldPresenceDuration == 0))
            {
                return (false, Messages.InvalidBattlefieldPresenceDuration);
            }


            return (true, "");
        }
    }
}
