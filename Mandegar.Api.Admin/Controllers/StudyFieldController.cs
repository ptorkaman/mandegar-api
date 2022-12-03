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
    /// رشته تحصیلی 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StudyFieldController : ApiBaseController
    {
        private readonly IStudyFieldService _studyFieldService;
        public StudyFieldController(IStudyFieldService studyFieldService)
        {
            _studyFieldService = studyFieldService;
        }

        /// <summary>
        /// حذف رشته تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.StudyFieldDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _studyFieldService.Delete(id);
        }

       

        /// <summary>
        /// افزودن رشته تحصیلی جدید
        /// </summary>
        /// <param name="studyField"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] StudyFieldVM studyField)
        {
            return await _studyFieldService.Add(studyField);
        }

        /// <summary>
        /// آماده سازی ویرایش رشته تحصیلی
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.StudyFieldEdit)]
        public async Task<Result<StudyFieldVM>> GetById([FromBody] int id)
        {
            var result = await _studyFieldService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی رشته تحصیلی
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StudyFieldEdit)]
        public async Task<Result<bool>> Update([FromBody] StudyFieldVM studyField)
        {
            var result = await _studyFieldService.Update(studyField);
            return result;
        }

        /// <summary>
        /// لیست رشته تحصیلی ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.StudyFieldManagement)]
        public async Task<Result<List<StudyFieldVM>>> GetAll()
        {
            return await _studyFieldService.GetAll();
        }
    }
}
