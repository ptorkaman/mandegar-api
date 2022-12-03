using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Sacrifices;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ISacrificeService
    {
        Task<Result<SacrificeVM>> Get(int staffId);
        Task<Result<bool>> Update(Sacrifice model);
    }
}
