using Mandegar.Models.Entities.BaseInfo;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IDepartmentMemberService
    {
        Task<Result<bool>> Add(DepartmentMemberVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(DepartmentMemberVM model);

        Task<Result<DepartmentMemberVM>> GetById(int id);

        Task<Result<List<DepartmentMemberVM>>> GetAll();

    }
}
