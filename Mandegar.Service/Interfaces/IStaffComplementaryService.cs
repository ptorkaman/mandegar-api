using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffComplementaries;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IStaffComplementaryService
    {
        Task<Result<StaffComplementaryVM>> Get(int staffId);
        Task<Result<bool>> Update(StaffComplementary model);
    }
}
