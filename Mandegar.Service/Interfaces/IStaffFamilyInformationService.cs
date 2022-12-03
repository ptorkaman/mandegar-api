using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffFamily;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IStaffFamilyInformationService
    {
        Task<Result<StaffFamilyInformationVM>> Get(int id);
        Task<Result<bool>> Update(StaffFamilyInformation model);
        Task<Result<bool>> Add(StaffFamilyInformation model);
        Task<Result<bool>> Delete(int id);
        Task<Result<List<StaffFamilyInformationVM>>> GetAll(int staffId);
    }
}
