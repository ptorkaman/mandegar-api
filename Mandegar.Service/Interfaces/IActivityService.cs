using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffActivities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IActivityService
    {
        Task<Result<ActivityVM>> Get(int id);
        Task<Result<bool>> Update(Activity model);
        Task<Result<bool>> Add(Activity model);
        Task<Result<bool>> Delete(int id);
        Task<Result<List<ActivityVM>>> GetAll(int staffId);
    }
}
