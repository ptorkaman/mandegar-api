using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface ICooperationTypeService
    {
        Task<Result<bool>> Add(CooperationTypeVM model);


        Task<Result<bool>> Delete(int id);

        Task<Result<bool>> Update(CooperationTypeVM model);

        Task<Result<CooperationTypeVM>> GetById(int id);

        Task<Result<List<CooperationType>>> GetAll();

    }
}
