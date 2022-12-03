using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.Staffs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IAssignPositionService
    {
        Task<Result<bool>> Add(AssignPositionVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<List<AssignPositionVM>>> GetById(int id);

        Task<Result<List<AssignPositionVM>>> GetAll();
        Task<Result<Root>> GetAllPositions();
        Task<Result<bool>> Update(AssignPositionVM assignPosition);
    }
}
