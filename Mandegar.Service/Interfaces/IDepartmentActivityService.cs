using Mandegar.Models.Entities.Departments;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IDepartmentActivityService
    {
        Task<Result<bool>> Add(DepartmentActivityVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(DepartmentActivityVM model);

        Task<Result<DepartmentActivityVM>> GetById(int id);

        Task<Result<List<DepartmentActivityVM>>> GetAll();

    }
}
