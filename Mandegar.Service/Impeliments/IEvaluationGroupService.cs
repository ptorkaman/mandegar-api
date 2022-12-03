using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.EvaluationGroup;
using Mandegar.Models.ViewModels.Shared;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public interface IEvaluationGroupService
    {
        Task<Result<bool>> Add(EvaluationGroupVM request);
        Task<Result<bool>> Delete(int id);
        Task<Result<PagingResultVM<EvaluationGroupResultVM>>> GetAll(EvaluationGroupSearchVM model);
        Task<Result<EvaluationGroupResultVM>> GetById(int id);
        Task<Result<bool>> Update(EvaluationGroupVM model);
        Task<Result<List<CollectionVM>>> Collection();
    }
}
