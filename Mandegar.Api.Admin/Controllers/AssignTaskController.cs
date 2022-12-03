using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using Mandegar.Models.ViewModels.Common;
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
    /// تخصیص وظیفه 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AssignTaskController : ApiBaseController
    {
        private readonly IAssignTaskService _assignTaskService;
        public AssignTaskController(IAssignTaskService assignTaskService)
        {
            _assignTaskService = assignTaskService;
        }

        /// <summary>
        /// حذف تخصیص وظیفه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.AssignTaskDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _assignTaskService.Delete(id);
        }

        /// <summary>
        /// افزودن تخصیص وظیفه جدید
        /// </summary>
        /// <param name="assignTask"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.AssignTaskAdd)]
        public async Task<Result<bool>> Add([FromBody] AssignTaskVM assignTask)
        {
            return await _assignTaskService.Add(assignTask);
        }

        /// <summary>
        /// آماده سازی ویرایش تخصیص وظیفه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.AssignTaskEdit)]
        public async Task<Result<AssignTaskVM>> GetById([FromBody] int id)
        {
            var result = await _assignTaskService.GetById(id);
            return result;
        }

       
        /// <summary>
        /// لیست تخصیص وظیفه ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.AssignTaskManagement)]
        public async Task<Result<List<AssignTaskVM>>> GetAll()
        {
            return await _assignTaskService.GetAll();
        }


        /// <summary>
        /// لیست  وظیفه ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAllTasks")]
        [AdminAuthorize((int)AdminAuthorize.AssignTaskManagement)]
        public async Task<Result<Root>> GetAllTasks()
        {
            return await _assignTaskService.GetAllTasks();
        }

        [HttpPost("GetAllByPositionId")]
        [AdminAuthorize((int)AdminAuthorize.AssignTaskEdit)]
        public async Task<Result<List<AssignTaskVM>>> GetAllByPositionId([FromBody] int id)
        {
            var result = await _assignTaskService.GetAllByPositionId(id);
            return result;
        }

        /// <summary>
        /// ویرایش تخصیص وظیفه
        /// </summary>
        /// <param name="assignTask"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.AssignTaskAdd)]
        public async Task<Result<bool>> Update([FromBody] AssignTaskVM modelVm)
        {
            return await _assignTaskService.Update(modelVm);
        }

    }
}
