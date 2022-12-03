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
    public class TaskController : ApiBaseController
    {
        private readonly ITaskService _taskService;
        public TaskController(ITaskService taskService)
        {
            _taskService = taskService;
        }

        /// <summary>
        /// حذف وظیفه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.TaskDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _taskService.Delete(id);
        }

       
       

        /// <summary>
        /// افزودن وظیفه جدید
        /// </summary>
        /// <param name="task"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] Models.Entities.Personeli.Tasks task)
        {
            return await _taskService.Add(task);
        }

        /// <summary>
        /// آماده سازی ویرایش وظیفه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.TaskEdit)]
        public async Task<Result<TaskVM>> GetById([FromBody] int id)
        {
            var result = await _taskService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی وظیفه
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.TaskEdit)]
        public async Task<Result<bool>> Update([FromBody] Tasks task)
        {
            var result = await _taskService.Update(task);
            return result;
        }

        /// <summary>
        /// لیست وظیفه ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.TaskManagement)]
        public async Task<Result<List<TaskVM>>> GetAll()
        {
            return await _taskService.GetAll();
        }
        /// <summary>
        /// لیست وظیفه ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAllByTaskGroupId")]
        [AdminAuthorize((int)AdminAuthorize.TaskManagement)]
        public async Task<Result<List<TaskVM>>> GetAllByTaskGroupId([FromBody] int id)
        {
            return await _taskService.GetAllByTaskGroupId(id);
        }
    }
}
