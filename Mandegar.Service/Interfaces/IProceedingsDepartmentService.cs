using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.DepartmentMeeting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IProceedingsDepartmentService
    {
        Task<Result<bool>> Add(ProceedingsDepartmentVM model);
        Task<Result<bool>> Update(ProceedingsDepartmentVM model);
        Task<Result<bool>> Delete(int id);
        Task<Result<ProceedingsDepartmentVM>> GetById(int id);
        Task<Result<PagingResultVM<ProceedingsDepartmentVM>>> GetAll(ProceedingsDepartmentSearchVM model);
    }
}
