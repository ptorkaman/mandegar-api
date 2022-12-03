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
    /// دروس دپارتمان 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class DepartmentLessonController : ApiBaseController
    {
        private readonly IDepartmentLessonService _departmentLessonService;
        public DepartmentLessonController(IDepartmentLessonService departmentLessonService)
        {
            _departmentLessonService = departmentLessonService;
        }

        /// <summary>
        /// حذف دروس دپارتمان
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentLessonDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _departmentLessonService.Delete(id);
        }

        /// <summary>
        ///  ویرایش دروس دپارتمان
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentLessonAdd)]
        public async Task<Result<bool>> Update([FromBody] DepartmentLessonVM departmentLesson)
        {
            var result = await _departmentLessonService.Update(departmentLesson);
            return result;
        }



        /// <summary>
        /// افزودن دروس دپارتمان جدید
        /// </summary>
        /// <param name="departmentLesson"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentLessonAdd)]
        public async Task<Result<bool>> Add([FromBody] DepartmentLesson departmentLesson)
        {
            return await _departmentLessonService.Add(departmentLesson);
        }

        /// <summary>
        /// آماده سازی ویرایش دروس دپارتمان
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentLessonEdit)]
        public async Task<Result<DepartmentLessonVM>> GetById([FromBody] int id)
        {
            var result = await _departmentLessonService.GetById(id);
            return result;
        }

       
        /// <summary>
        /// لیست دروس دپارتمان ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.DepartmentLessonManagement)]
        public async Task<Result<List<DepartmentLessonVM>>> GetAll()
        {
            return await _departmentLessonService.GetAll();
        }
    }
}
