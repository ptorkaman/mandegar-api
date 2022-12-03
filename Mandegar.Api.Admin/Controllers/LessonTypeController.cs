using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.BaseInfo;
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
    /// انواع درس 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LessonTypeController : ApiBaseController
    {
        private readonly ILessonTypeService _taskGroupService;
        public LessonTypeController(ILessonTypeService taskGroupService)
        {
            _taskGroupService = taskGroupService;
        }

        /// <summary>
        /// حذف انواع درس
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.LessonTypeDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _taskGroupService.Delete(id);
        }

       

        /// <summary>
        /// افزودن انواع درس جدید
        /// </summary>
        /// <param name="taskGroup"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] LessonTypeVM taskGroup)
        {
            return await _taskGroupService.Add(taskGroup);
        }

        /// <summary>
        /// آماده سازی ویرایش انواع درس
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.LessonTypeEdit)]
        public async Task<Result<LessonTypeVM>> GetById([FromBody] int id)
        {
            var result = await _taskGroupService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی انواع درس
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.LessonTypeEdit)]
        public async Task<Result<bool>> Update([FromBody] LessonTypeVM taskGroup)
        {
            var result = await _taskGroupService.Update(taskGroup);
            return result;
        }

        /// <summary>
        /// لیست انواع درس ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.LessonTypeManagement)]
        public async Task<Result<List<LessonType>>> GetAll()
        {
            return await _taskGroupService.GetAll();
        }
    }
}
