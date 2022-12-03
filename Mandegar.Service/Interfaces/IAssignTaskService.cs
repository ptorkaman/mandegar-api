using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using Mandegar.Models.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IAssignTaskService
    {
        Task<Result<bool>> Add(AssignTaskVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<AssignTaskVM>> GetById(int id);

        Task<Result<List<AssignTaskVM>>> GetAll();
        Task<Result<Root>> GetAllTasks();
        Task<Result<List<AssignTaskVM>>> GetAllByPositionId(int id);
        Task<Result<bool>> Update(AssignTaskVM model);
    }
}
