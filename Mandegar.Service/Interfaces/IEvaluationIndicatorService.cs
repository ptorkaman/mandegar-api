using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.EvaluationIndicator;
using Mandegar.Models.ViewModels.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IEvaluationIndicatorService
    {
        Task<Result<PagingResultVM<EvaluationIndicatorResultVM>>> GetAll(EvaluationIndicatorSearchVM model);
        Task<Result<EvaluationIndicator>> GetById(int id);
        Task<Result<bool>> Add(EvaluationIndicatorVM request);
        Task<Result<bool>> Update(EvaluationIndicatorVM request);
        Task<Result<bool>> Delete(int id);
        Task<Result<List<CollectionVM>>> Collection();
    }
}
