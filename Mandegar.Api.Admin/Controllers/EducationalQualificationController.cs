using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.EducationalQualifications;
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
    public class EducationalQualificationController : ApiBaseController
    {
        private readonly IEducationalQualificationService _educationalQualificationService;

        public EducationalQualificationController(IEducationalQualificationService EducationalQualificationService)
        {
            _educationalQualificationService = EducationalQualificationService;
        }

        /// <summary>
        /// دریافت مدرک آموزشی
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<EducationalQualificationVM>> Get([FromQuery] int id)
        {
            return await _educationalQualificationService.Get(id);
        }

        /// <summary>
        /// افزودن مدرک آموزشی
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Add(EducationalQualificationVM model)
        {
            return await _educationalQualificationService.Add((EducationalQualification)model);
        }
        /// <summary>
        /// ویرایش مدرک آموزشی
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Update(EducationalQualificationVM model)
        {
            return await _educationalQualificationService.Update((EducationalQualification)model);

        }

        /// <summary>
        /// حذف مدرک آموزشی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _educationalQualificationService.Delete(id);
        }

        /// <summary>
        /// دریافت مدرک آموزشی
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<List<EducationalQualificationVM>>> GetAll([FromQuery] int staffId)
        {
            return await _educationalQualificationService.GetAll(staffId);
        }
    }
}
