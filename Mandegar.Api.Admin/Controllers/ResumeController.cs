using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffResumes;
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
    public class ResumeController : ApiBaseController
    {
        private readonly IResumeService _resumeService;

        public ResumeController(IResumeService resumeService)
        {
            _resumeService = resumeService;
        }

        /// <summary>
        /// دریافت سابقه کاری
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<ResumeVM>> Get([FromQuery] int id)
        {
            return await _resumeService.Get(id);
        }

        /// <summary>
        /// افزودن سابقه کاری
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Add(ResumeVM model)
        {
            return await _resumeService.Add((Resume)model);
        }
        /// <summary>
        /// ویرایش سابقه کاری
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Update(ResumeVM model)
        {
            return await _resumeService.Update((Resume)model);

        }

        /// <summary>
        /// حذف سابقه کاری
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _resumeService.Delete(id);
        }

        /// <summary>
        /// دریافت سابقه کاری
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<List<ResumeVM>>> GetAll([FromQuery] int staffId)
        {
            var lst = new List<ResumeVM>();

            return await _resumeService.GetAll(staffId);
        }
    }
}
