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
    /// مورد همکاری 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    //[Authorize]
    public class ActivityCaseController : ApiBaseController
    {
        private readonly IActivityCaseService _activityCaseService;
        public ActivityCaseController(IActivityCaseService activityCaseService)
        {
            _activityCaseService = activityCaseService;
        }

        /// <summary>
        /// حذف مورد همکاری
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.ActivityCaseDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _activityCaseService.Delete(id);
        }

        /// <summary>
        /// افزودن مورد همکاری جدید
        /// </summary>
        /// <param name="activityCase"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.ActivityCaseAdd)]
        public async Task<Result<bool>> Add([FromBody] ActivityCaseVM activityCase)
        {
            return await _activityCaseService.Add(activityCase);
        }

        /// <summary>
        /// آماده سازی ویرایش مورد همکاری
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.ActivityCaseEdit)]
        public async Task<Result<ActivityCaseVM>> GetById([FromBody] int id)
        {
            var result = await _activityCaseService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی مورد همکاری
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.ActivityCaseEdit)]
        public async Task<Result<bool>> Update([FromBody] ActivityCaseVM activityCase)
        {
            var result = await _activityCaseService.Update(activityCase);
            return result;
        }

        /// <summary>
        /// لیست مورد همکاری ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.ActivityCaseManagement)]
        public async Task<Result<List<ActivityCase>>> GetAll()
        {
            return await _activityCaseService.GetAll();
        }
    }
}
