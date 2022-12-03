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
    /// درس 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class LessonController : ApiBaseController
    {
        private readonly ILessonService _taskGroupService;
        public LessonController(ILessonService taskGroupService)
        {
            _taskGroupService = taskGroupService;
        }

        /// <summary>
        /// حذف درس
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.LessonDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _taskGroupService.Delete(id);
        }

       

        /// <summary>
        /// افزودن درس جدید
        /// </summary>
        /// <param name="taskGroup"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] LessonVM taskGroup)
        {
            return await _taskGroupService.Add(taskGroup);
        }

        /// <summary>
        /// آماده سازی ویرایش درس
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.LessonEdit)]
        public async Task<Result<LessonVM>> GetById([FromBody] int id)
        {
            var result = await _taskGroupService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی درس
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.LessonEdit)]
        public async Task<Result<bool>> Update([FromBody] LessonVM taskGroup)
        {
            var result = await _taskGroupService.Update(taskGroup);
            return result;
        }

        /// <summary>
        /// لیست درس ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.LessonManagement)]
        public async Task<Result<List<LessonVM>>> GetAll()
        {
            return await _taskGroupService.GetAll();
        }
    }
}
