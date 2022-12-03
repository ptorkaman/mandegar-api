using Mandegar.CoreBase.Controller;
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
    /// وظیفه 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TaskGroupController : ApiBaseController
    {
        private readonly ITaskGroupService _taskGroupService;
        public TaskGroupController(ITaskGroupService taskGroupService)
        {
            _taskGroupService = taskGroupService;
        }

        /// <summary>
        /// حذف وظیفه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.TaskGroupDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _taskGroupService.Delete(id);
        }

       

        /// <summary>
        /// افزودن وظیفه جدید
        /// </summary>
        /// <param name="taskGroup"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] TaskGroupVM taskGroup)
        {
            return await _taskGroupService.Add(taskGroup);
        }

        /// <summary>
        /// آماده سازی ویرایش وظیفه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.TaskGroupEdit)]
        public async Task<Result<TaskGroupVM>> GetById([FromBody] int id)
        {
            var result = await _taskGroupService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی وظیفه
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.TaskGroupEdit)]
        public async Task<Result<bool>> Update([FromBody] TaskGroupVM taskGroup)
        {
            var result = await _taskGroupService.Update(taskGroup);
            return result;
        }

        /// <summary>
        /// لیست وظیفه ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.TaskGroupManagement)]
        public async Task<Result<List<TaskGroup>>> GetAll()
        {
            return await _taskGroupService.GetAll();
        }
    }
}
