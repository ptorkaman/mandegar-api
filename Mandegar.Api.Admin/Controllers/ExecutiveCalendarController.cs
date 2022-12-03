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
    /// سال تحصیلی 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class ExecutiveCalendarController : ApiBaseController
    {
        private readonly IExecutiveCalendarService _executiveCalendarService;
        public ExecutiveCalendarController(IExecutiveCalendarService executiveCalendarService)
        {
            _executiveCalendarService = executiveCalendarService;
        }

        /// <summary>
        /// حذف سال تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.ExecutiveCalendarDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _executiveCalendarService.Delete(id);
        }

       

        /// <summary>
        /// افزودن سال تحصیلی جدید
        /// </summary>
        /// <param name="executiveCalendar"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] ExecutiveCalendarVM executiveCalendar)
        {
            return await _executiveCalendarService.Add(executiveCalendar);
        }

        /// <summary>
        /// آماده سازی ویرایش سال تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.ExecutiveCalendarEdit)]
        public async Task<Result<ExecutiveCalendarVM>> GetById([FromBody] int id)
        {
            var result = await _executiveCalendarService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی سال تحصیلی
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.ExecutiveCalendarEdit)]
        public async Task<Result<bool>> Update([FromBody] ExecutiveCalendarVM executiveCalendar)
        {
            var result = await _executiveCalendarService.Update(executiveCalendar);
            return result;
        }

        /// <summary>
        /// لیست سال تحصیلی ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.ExecutiveCalendarManagement)]
        public async Task<Result<List<ExecutiveCalendarVM>>> GetAll()
        {
            return await _executiveCalendarService.GetAll();
        }
    }
}
