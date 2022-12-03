using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.DepartmentMeeting;
using Mandegar.Models.ViewModels.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IDepartmentMeetingMember
    {
        Task<Result<bool>> Add(MeetingMemberVM model);
        Task<Result<bool>> Update(MeetingMemberVM model);
        Task<Result<bool>> Delete(int id);
        Task<Result<MeetingMemberVM>> GetById(int id);
        Task<Result<PagingResultVM<DepartmentMeetingMemberVM>>> GetAll(DepartmentMeetingMemberSearchVM model);
        Task<Result<List<CollectionVM>>> Collection(int? id);
        Task<Result<List<DepartmentStaffVM>>> GetAllMembers(int id);
    }
}
