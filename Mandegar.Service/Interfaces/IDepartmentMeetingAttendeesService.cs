using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.DepartmentMeeting;
using Mandegar.Models.ViewModels.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IDepartmentMeetingAttendeesService
    {
        Task<Result<bool>> Add(DepartmentMeetingAttendeesVM model);
        Task<Result<bool>> Update(DepartmentMeetingAttendeesVM model);
        Task<Result<bool>> Delete(int id);
        Task<Result<DepartmentMeetingAttendeesVM>> GetById(int id);
        Task<Result<PagingResultVM<DepartmentMeetingAttendeesResultVM>>> GetAll(DepartmentMeetingAttendeesSearchVM model);
        Task<Result<List<DepartmentMeetingAttendeesResultVM>>> GetAllMembers(int id);
        Task<Result<List<CollectionVM>>> Collection(int? id);
    }
}
