using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IDepartmentActivityTypeService
    {
        Task<Result<bool>> Add(DepartmentActivityTypeVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(DepartmentActivityTypeVM model);

        Task<Result<DepartmentActivityTypeVM>> GetById(int id);

        Task<Result<List<DepartmentActivityType>>> GetAll();

    }
}
