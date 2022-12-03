using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffFinancials;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.ActionFilters;
using Mandegar.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StaffFinancialController : ApiBaseController
    {
        private readonly IStaffFinancialService _StaffFinancialService;

        public StaffFinancialController(IStaffFinancialService StaffFinancialService)
        {
            _StaffFinancialService = StaffFinancialService;
        }

        /// <summary>
        /// دریافت اطلاعات مالی
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<StaffFinancialVM>> Get([FromQuery] int id)
        {
            return await _StaffFinancialService.Get(id);
        }

        /// <summary>
        /// افزودن اطلاعات مالی
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Add(StaffFinancialVM model)
        {
            return await _StaffFinancialService.Add((StaffFinancial)model);
        }
        /// <summary>
        /// ویرایش اطلاعات مالی
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Update(StaffFinancialVM model)
        {
            return await _StaffFinancialService.Update((StaffFinancial)model);

        }

        /// <summary>
        /// حذف اطلاعات مالی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _StaffFinancialService.Delete(id);
        }

        /// <summary>
        /// دریافت اطلاعات مالی
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<List<StaffFinancialVM>>> GetAll([FromQuery] int staffId)
        {
            return await _StaffFinancialService.GetAll(staffId);
        }
    }
}
