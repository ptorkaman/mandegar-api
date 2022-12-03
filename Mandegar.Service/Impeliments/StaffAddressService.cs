using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffAddresses;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class StaffAddressService : IStaffAddressService
    {
        private readonly IUow _uow;

        public StaffAddressService(IUow uow)
        {
            _uow = uow;
        }

        public async Task<Result<bool>> Update(StaffAddress model)
        {
            var validate = Validate(model);
            if (!validate.success)
            {
                return new Result<bool>(message: validate.message);
            }

            var data = await _uow.GetRepository<StaffAddress>().Get(c => c.StaffId == model.StaffId).FirstOrDefaultAsync();

            if (data == null)
            {
                model.CreatedById = ClaimHelper.GetUserId();

                await _uow.GetRepository<StaffAddress>().AddAsync(model);
                await _uow.SaveChangesAsync();
                return new Result<bool>(true);
            }

            data.ModifiedById = ClaimHelper.GetUserId();
            data.ModifiedOn = DateTime.Now;

            data.AddressTypeId = model.AddressTypeId;
            data.OtherWorkPhone = model.OtherWorkPhone;
            data.OtherWorkName = model.OtherWorkName;
            data.Address = model.Address;
            data.Description = model.Description;
            data.Email = model.Email;
            data.Mobile1 = model.Mobile1;
            data.Mobile2 = model.Mobile2;
            data.Phone = model.Phone;

            await _uow.SaveChangesAsync();

            return new Result<bool>(true);
        }

        public async Task<Result<StaffAddressVM>> Get(int staffId)
        {
            if (staffId == 0)
            {
                return new Result<StaffAddressVM>(message: Messages.NotExistsData);
            }

            var data = await _uow.GetRepository<StaffAddress>().Get(c => c.StaffId == staffId).FirstOrDefaultAsync();

            return new Result<StaffAddressVM>((StaffAddressVM)data);
        }

        private (bool success, string message) Validate(StaffAddress model)
        {
            if (model == null)
            {
                return (false, Messages.NotExistsData);
            }

            if (string.IsNullOrWhiteSpace(model.Phone) || model?.Phone.Length != 11)
            {
                return (false, Messages.InvalidPhone);
            }

            if (string.IsNullOrWhiteSpace(model.Mobile1) || model?.Mobile1.Length != 11)
            {
                return (false, Messages.InvalidMobile);
            }

            if (string.IsNullOrWhiteSpace(model.Address) || model?.Address.Length > 200)
            {
                return (false, Messages.InvalidAddress);
            }

            if (string.IsNullOrWhiteSpace(model.Email) || model?.Email.Length >= 100)
            {
                return (false, Messages.InvalidEmail);
            }

            return (true, "");
        }
    }
}
