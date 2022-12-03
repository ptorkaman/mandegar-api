using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ITaskService
    {
        Task<Result<bool>> Add(Tasks model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(Models.Entities.Personeli.Tasks model);

        Task<Result<TaskVM>> GetById(int id);

        Task<Result<List<TaskVM>>> GetAll();
        Task<Result<List<Tasks>>> GetAllTasks();
        Task<Result<List<TaskVM>>> GetAllByTaskGroupId(int taskGroupId);
    }
}
