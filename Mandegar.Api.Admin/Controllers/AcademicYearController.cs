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
    public class AcademicYearController : ApiBaseController
    {
        private readonly IAcademicYearService _academicYearService;
        public AcademicYearController(IAcademicYearService academicYearService)
        {
            _academicYearService = academicYearService;
        }

        /// <summary>
        /// حذف سال تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.AcademicYearDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _academicYearService.Delete(id);
        }

       

        /// <summary>
        /// افزودن سال تحصیلی جدید
        /// </summary>
        /// <param name="academicYear"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] AcademicYearVM academicYear)
        {
            return await _academicYearService.Add(academicYear);
        }

        /// <summary>
        /// آماده سازی ویرایش سال تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.AcademicYearEdit)]
        public async Task<Result<AcademicYearVM>> GetById([FromBody] int id)
        {
            var result = await _academicYearService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی سال تحصیلی
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.AcademicYearEdit)]
        public async Task<Result<bool>> Update([FromBody] AcademicYearVM academicYear)
        {
            var result = await _academicYearService.Update(academicYear);
            return result;
        }

        /// <summary>
        /// لیست سال تحصیلی ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.AcademicYearManagement)]
        public async Task<Result<List<AcademicYear>>> GetAll()
        {
            return await _academicYearService.GetAll();
        }
    }
}
