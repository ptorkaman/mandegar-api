using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.SessionApproval;
using Mandegar.Models.ViewModels.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ISessionApprovalsService
    {
        Task<Result<PagingResultVM<SessionApprovalResultVM>>> GetAll(SessionApprovalSearchVM request);
        Task<Result<SessionApprovalVM>> GetById(int id);
        Task<Result<bool>> Delete(int id);
        Task<Result<bool>> Add(SessionApprovalVM model);
        Task<Result<bool>> Update(SessionApprovalVM model);
        Task<Result<List<SessionApprovalResultVM>>> GetAllMembers(int id);
    }
}
