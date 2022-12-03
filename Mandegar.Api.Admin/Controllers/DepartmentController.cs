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
    /// دپارتمان 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DepartmentController : ApiBaseController
    {
        private readonly IDepartmentService _departmentService;
        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        /// <summary>
        /// حذف دپارتمان
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _departmentService.Delete(id);
        }

        /// <summary>
        /// افزودن دپارتمان جدید
        /// </summary>
        /// <param name="department"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] DepartmentVM department)
        {
            return await _departmentService.Add(department);
        }

        /// <summary>
        /// آماده سازی ویرایش دپارتمان
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentEdit)]
        public async Task<Result<DepartmentVM>> GetById([FromBody] int id)
        {
            var result = await _departmentService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی دپارتمان
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentEdit)]
        public async Task<Result<bool>> Update([FromBody] DepartmentVM department)
        {
            var result = await _departmentService.Update(department);
            return result;
        }

        /// <summary>
        /// لیست دپارتمان ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentManagement)]
        public async Task<Result<List<DepartmentVM>>> GetAll()
        {
            return await _departmentService.GetAll();
        }
    }
}
