using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Cooperations;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ICooperationService
    {
        Task<Result<CooperationVM>> Get(int staffId);
        Task<Result<bool>> Update(Cooperation model);
    }
}
