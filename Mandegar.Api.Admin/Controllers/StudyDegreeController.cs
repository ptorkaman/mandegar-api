using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.BaseInfo;
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
    /// مقطع تحصیلی 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudyDegreeController : ApiBaseController
    {
        private readonly IStudyDegreeService _studyDegreeService;
        public StudyDegreeController(IStudyDegreeService studyDegreeService)
        {
            _studyDegreeService = studyDegreeService;
        }

        /// <summary>
        /// حذف مقطع تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.StudyDegreeDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _studyDegreeService.Delete(id);
        }

       

        /// <summary>
        /// افزودن مقطع تحصیلی جدید
        /// </summary>
        /// <param name="studyDegree"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] StudyDegreeVM studyDegree)
        {
            return await _studyDegreeService.Add(studyDegree);
        }

        /// <summary>
        /// آماده سازی ویرایش مقطع تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.StudyDegreeEdit)]
        public async Task<Result<StudyDegreeVM>> GetById([FromBody] int id)
        {
            var result = await _studyDegreeService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی مقطع تحصیلی
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StudyDegreeEdit)]
        public async Task<Result<bool>> Update([FromBody] StudyDegreeVM studyDegree)
        {
            var result = await _studyDegreeService.Update(studyDegree);
            return result;
        }

        /// <summary>
        /// لیست مقطع تحصیلی ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.StudyDegreeManagement)]
        public async Task<Result<List<StudyDegree>>> GetAll()
        {
            return await _studyDegreeService.GetAll();
        }
    }
}
