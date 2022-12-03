using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffActivities;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.ActionFilters;
using Mandegar.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ActivityController : ApiBaseController
    {
        private readonly IActivityService _activityService;

        public ActivityController(IActivityService activityService)
        {
            _activityService = activityService;
        }

        /// <summary>
        /// دریافت فعالیت
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<ActivityVM>> Get([FromQuery] int id)
        {
            return await _activityService.Get(id);
        }

        /// <summary>
        /// افزودن فعالیت
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Add(ActivityVM model)
        {
            return await _activityService.Add((Activity)model);
        }
        /// <summary>
        /// ویرایش فعالیت
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Update(ActivityVM model)
        {
            return await _activityService.Update((Activity)model);

        }

        /// <summary>
        /// حذف فعالیت
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _activityService.Delete(id);
        }

        /// <summary>
        /// دریافت فعالیت
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<List<ActivityVM>>> GetAll([FromQuery] int staffId)
        {
            return await _activityService.GetAll(staffId);
        }
    }
}
