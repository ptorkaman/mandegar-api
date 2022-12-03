using Mandegar.CoreBase.Controller;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.DepartmentMeeting;
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
    /// برنامه های دپارتمان  
    /// </summary>

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class DepartmentScheduleController : ApiBaseController
    {
        private readonly IDepartmentScheduleService _departmentScheduleService;
        public DepartmentScheduleController(IDepartmentScheduleService service)
        {
            _departmentScheduleService = service;
        }

        [HttpPost(nameof(Collection))]
        public async Task<Result<List<DepartmentScheduleVM>>> Collection()
        {
            return await _departmentScheduleService.Collection();
        }

        /// <summary>
        /// حذف برنامه دپارتمان
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentScheduleDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _departmentScheduleService.Delete(id);
        }



        /// <summary>
        /// افزودن برنامه دپارتمان جدید
        /// </summary>
        /// <param name="academicYear"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] DepartmentScheduleVM modelVm)
        {
            return await _departmentScheduleService.Add(modelVm);
        }

        /// <summary>
        /// آماده سازی ویرایش برنامه دپارتمان
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentScheduleEdit)]
        public async Task<Result<DepartmentScheduleVM>> GetById([FromBody] int id)
        {
            var result = await _departmentScheduleService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی برنامه دپارتمان
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentScheduleEdit)]
        public async Task<Result<bool>> Update([FromBody] DepartmentScheduleVM modelVm)
        {
            var result = await _departmentScheduleService.Update(modelVm);
            return result;
        }

        /// <summary>
        /// لیست برنامه دپارتمان
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentScheduleManagement)]
        public async Task<Result<PagingResultVM<DepartmentScheduleVM>>> GetAll([FromQuery] DepartmentScheduleVM modelVm)
        {
            return await _departmentScheduleService.GetAll(modelVm);
        }

    }
}
