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
    /// پایه تحصیلی 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudyGradeController : ApiBaseController
    {
        private readonly IStudyGradeService _studyGradeService;
        public StudyGradeController(IStudyGradeService studyGradeService)
        {
            _studyGradeService = studyGradeService;
        }

        /// <summary>
        /// حذف پایه تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.StudyGradeDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _studyGradeService.Delete(id);
        }

       

        /// <summary>
        /// افزودن پایه تحصیلی جدید
        /// </summary>
        /// <param name="studyGrade"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] StudyGradeVM studyGrade)
        {
            return await _studyGradeService.Add(studyGrade);
        }

        /// <summary>
        /// آماده سازی ویرایش پایه تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.StudyGradeEdit)]
        public async Task<Result<StudyGradeVM>> GetById([FromBody] int id)
        {
            var result = await _studyGradeService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی پایه تحصیلی
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StudyGradeEdit)]
        public async Task<Result<bool>> Update([FromBody] StudyGradeVM studyGrade)
        {
            var result = await _studyGradeService.Update(studyGrade);
            return result;
        }

        /// <summary>
        /// لیست پایه تحصیلی ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.StudyGradeManagement)]
        public async Task<Result<List<StudyGradeVM>>> GetAll()
        {
            return await _studyGradeService.GetAll();
        }
    }
}
