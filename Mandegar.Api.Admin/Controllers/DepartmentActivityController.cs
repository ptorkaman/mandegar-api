using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Departments;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
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
    /// فعالیت دپارتمان 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DepartmentActivityController : ApiBaseController
    {
        private readonly IDepartmentActivityService _departmentActivityService;
        public DepartmentActivityController(IDepartmentActivityService departmentActivityService)
        {
            _departmentActivityService = departmentActivityService;
        }

        /// <summary>
        /// حذف فعالیت دپارتمان
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentActivityDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _departmentActivityService.Delete(id);
        }

        /// <summary>
        /// افزودن فعالیت دپارتمان جدید
        /// </summary>
        /// <param name="departmentActivity"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] DepartmentActivityVM departmentActivity)
        {
            return await _departmentActivityService.Add(departmentActivity);
        }

        /// <summary>
        /// آماده سازی ویرایش فعالیت دپارتمان
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentActivityEdit)]
        public async Task<Result<DepartmentActivityVM>> GetById([FromBody] int id)
        {
            var result = await _departmentActivityService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی فعالیت دپارتمان
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentActivityEdit)]
        public async Task<Result<bool>> Update([FromBody] DepartmentActivityVM departmentActivity)
        {
            var result = await _departmentActivityService.Update(departmentActivity);
            return result;
        }

        /// <summary>
        /// لیست فعالیت دپارتمان ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentActivityManagement)]
        public async Task<Result<List<DepartmentActivityVM>>> GetAll()
        {
            return await _departmentActivityService.GetAll();
        }
    }
}
