using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IExecutiveCalendarService
    {
        Task<Result<bool>> Add(ExecutiveCalendarVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(ExecutiveCalendarVM model);

        Task<Result<ExecutiveCalendarVM>> GetById(int id);

        Task<Result<List<ExecutiveCalendarVM>>> GetAll();

    }
}
