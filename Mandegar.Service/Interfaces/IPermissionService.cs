using Mandegar.Models.Entities.User;
using Mandegar.Models.HelperModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<Result<List<Permission>>> GetAllPermissions();
    }
}
