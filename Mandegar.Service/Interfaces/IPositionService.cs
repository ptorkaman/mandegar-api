using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IPositionService
    {
        Task<Result<bool>> Add(PositionVM model);

        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(PositionVM model);

        Task<Result<PositionVM>> GetById(int id);

        Task<Result<List<PositionVM>>> GetAll();
        Task<Result<List<Position>>> GetAllPositions();
    }
}
