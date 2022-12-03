using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffAddresses;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IStaffAddressService
    {
        Task<Result<StaffAddressVM>> Get(int staffId);
        Task<Result<bool>> Update(StaffAddress model);
    }
}
