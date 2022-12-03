using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IActivityCaseService
    {
        Task<Result<bool>> Add(ActivityCaseVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(ActivityCaseVM model);

        Task<Result<ActivityCaseVM>> GetById(int id);

        Task<Result<List<ActivityCase>>> GetAll();

    }
}
