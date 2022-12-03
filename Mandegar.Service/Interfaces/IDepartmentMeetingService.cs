using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.DepartmentMeeting;
using Mandegar.Models.ViewModels.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IDepartmentMeetingService
    {
        Task<Result<bool>> Add(DepartmentMeetingVM model);
        Task<Result<bool>> Update(DepartmentMeetingVM model);
        Task<Result<bool>> Delete(int id);
        Task<Result<DepartmentMeeting>> GetById(int id);
        Task<Result<PagingResultVM<DepartmentMeeting>>> GetAll(DepartmentMeetingSearchVM model);
        Task<Result<List<CollectionVM>>> Collection();
    }
}
