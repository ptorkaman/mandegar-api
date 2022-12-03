using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IDepartmentService
    {
        Task<Result<bool>> Add(DepartmentVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(DepartmentVM model);

        Task<Result<DepartmentVM>> GetById(int id);

        Task<Result<List<DepartmentVM>>> GetAll();

    }
}
