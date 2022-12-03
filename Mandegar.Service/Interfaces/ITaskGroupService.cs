using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ITaskGroupService
    {
        Task<Result<bool>> Add(TaskGroupVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(TaskGroupVM model);

        Task<Result<TaskGroupVM>> GetById(int id);

        Task<Result<List<TaskGroup>>> GetAll();

    }
}
