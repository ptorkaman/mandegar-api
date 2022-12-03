using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.Staffs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IStaffService
    {

        Task<Result<PagingResultVM<StaffListResultVM>>> GetAll(StaffSearchVM searchVM);
        Task<Result<bool>> Delete(int id);
        Task<Result<List<Staff>>> GetAllStaff();
        Task<Result<int>> Add(UpsertStaffVM model);
        Task<Result<UpsertStaffVM>> Get(int id);
        Task<Result<bool>> Update(UpsertStaffVM model);
        Task<Result<bool>> ExistsStaff(int id);
        Task<Result<List<StaffListResultVM>>> GetAllStaffBaseInfo();
        Task<Result<StaffListResultVM>> UpdatePreparation(int id);
        Task<Result<List<StaffListResultVM>>> GetAll();
    }
}
