using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Departments;
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
    /// نوع فعالیت 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DepartmentActivityTypeController : ApiBaseController
    {
        private readonly IDepartmentActivityTypeService _departmentActivityTypeService;
        public DepartmentActivityTypeController(IDepartmentActivityTypeService departmentActivityTypeService)
        {
            _departmentActivityTypeService = departmentActivityTypeService;
        }

        /// <summary>
        /// حذف نوع فعالیت
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentActivityTypeDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _departmentActivityTypeService.Delete(id);
        }

       

        /// <summary>
        /// افزودن نوع فعالیت جدید
        /// </summary>
        /// <param name="departmentActivityType"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] DepartmentActivityTypeVM departmentActivityType)
        {
            return await _departmentActivityTypeService.Add(departmentActivityType);
        }

        /// <summary>
        /// آماده سازی ویرایش نوع فعالیت
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentActivityTypeEdit)]
        public async Task<Result<DepartmentActivityTypeVM>> GetById([FromBody] int id)
        {
            var result = await _departmentActivityTypeService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی نوع فعالیت
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentActivityTypeEdit)]
        public async Task<Result<bool>> Update([FromBody] DepartmentActivityTypeVM departmentActivityType)
        {
            var result = await _departmentActivityTypeService.Update(departmentActivityType);
            return result;
        }

        /// <summary>
        /// لیست نوع فعالیت ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentActivityTypeManagement)]
        public async Task<Result<List<DepartmentActivityType>>> GetAll()
        {
            return await _departmentActivityTypeService.GetAll();
        }
    }
}
