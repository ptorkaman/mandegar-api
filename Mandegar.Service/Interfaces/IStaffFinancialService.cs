using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffFinancials;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IStaffFinancialService
    {
        Task<Result<StaffFinancialVM>> Get(int id);
        Task<Result<bool>> Update(StaffFinancial model);
        Task<Result<bool>> Add(StaffFinancial model);
        Task<Result<bool>> Delete(int id);
        Task<Result<List<StaffFinancialVM>>> GetAll(int staffId);
    }
}
