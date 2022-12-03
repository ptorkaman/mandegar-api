using Mandegar.Models.Entities.User;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Account;
using Mandegar.Models.ViewModels.Common;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IRoleService
    {
        Task<Result<bool>> Add(Role model);

        Task<Result<CreateRoleVM>> CreatePreparation();
        Task<Result<Root>> GetAllPermissionsAsync();

        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(Role model);

        Task<Result<CreateRoleVM>> UpdatePreparation(int id);

        Task<Result<List<Role>>> GetAll();

    }
}
