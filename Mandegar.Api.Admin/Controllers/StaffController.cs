using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.Staffs;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.ActionFilters;
using Mandegar.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    /// <summary>
    /// پرسنل
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StaffController : ApiBaseController
    {
        private readonly IStaffService _staffService;

        public StaffController(IStaffService staffService)
        {
            _staffService = staffService;
        }


        /// <summary>
        /// لیست کارکنان با جستجو
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<PagingResultVM<StaffListResultVM>>> GetAll([FromQuery] StaffSearchVM searchVM)
        {
            return await _staffService.GetAll(searchVM);
        }

        /// <summary>
        /// حذف پرسنل
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.StaffDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _staffService.Delete(id);
        }

        /// <summary>
        /// لیست کارکنان
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAllStaff")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<List<Staff>>> GetAllStaff()
        {
            return await _staffService.GetAllStaff();
        }

        /// <summary>
        /// افزودن پرسنل
        /// </summary>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.StaffAdd)]
        public async Task<Result<int>> Add([FromBody] UpsertStaffVM model)
        {
            return await _staffService.Add(model);
        }

        /// <summary>
        /// دریافت پرسنل
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [AdminAuthorize((int)AdminAuthorize.StaffEdit)]
        public async Task<Result<UpsertStaffVM>> Get([FromQuery] int id)
        {
            return await _staffService.Get(id);
        }

        /// <summary>
        /// ویرایش پرسنل
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StaffEdit)]
        public async Task<Result<bool>> Update([FromBody] UpsertStaffVM model)
        {
            return await _staffService.Update(model);
        }

        [HttpPost("ExistsStaff")]
        [AdminAuthorize((int)AdminAuthorize.StaffAdd)]
        public async Task<Result<bool>> ExistsStaff([FromBody] int id)
        {
            return await _staffService.ExistsStaff(id);
        }

        /// <summary>
        ///  اطلاعات  کارکنان برای اعضای دپارتمان
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAllStaffBaseInfo")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<List<StaffListResultVM>>> GetAllStaffBaseInfo()
        {
            return await _staffService.GetAllStaffBaseInfo();
        }
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<List<StaffListResultVM>>> GetAll()
        {
            return await _staffService.GetAll();
        }

        /// <summary>
        /// آماده سازی ویرایش پرسنل
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("UpdatePreparation")]
        [AdminAuthorize((int)AdminAuthorize.StaffEdit)]
        public async Task<Result<StaffListResultVM>> UpdatePreparation([FromBody] int id)
        {
            var result = await _staffService.UpdatePreparation(id);
            return result;
        }

    }
}
