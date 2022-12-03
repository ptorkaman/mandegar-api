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
    public interface IDepartmentScheduleService
    {
        Task<Result<List<DepartmentScheduleVM>>> Collection();
        Task<Result<bool>> Add(DepartmentScheduleVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(DepartmentScheduleVM model);

        Task<Result<DepartmentScheduleVM>> GetById(int id);

        Task<Result<PagingResultVM<DepartmentScheduleVM>>> GetAll(DepartmentScheduleVM modelVm);
    }
}
