using Mandegar.CoreBase.Controller;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.DepartmentMeeting;
using Mandegar.Models.ViewModels.Shared;
using Mandegar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    /// <summary>
    /// حاضرین جلسه
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentMeetingAttendeesController : ApiBaseController
    {
        private readonly IDepartmentMeetingAttendeesService _service;
        public DepartmentMeetingAttendeesController(IDepartmentMeetingAttendeesService service)
        {
            _service = service;
        }

        /// <summary>
        /// حذف حاضرین جلسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Delete))]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _service.Delete(id);
        }

        /// <summary>
        /// افزودن حاضرین جلسه
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Add))]
        public async Task<Result<bool>> Add([FromBody] DepartmentMeetingAttendeesVM model)
        {
            return await _service.Add(model);
        }

        /// <summary>
        /// دریافت حاضرین جلسه بر اساس شناسه جلسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Get))]
        public async Task<Result<DepartmentMeetingAttendeesVM>> Get([FromBody] int id)
        {
            return await _service.GetById(id);
        }

        /// <summary>
        /// بروز رسانی حاضرین جلسه
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Update))]
        public async Task<Result<bool>> Update([FromBody] DepartmentMeetingAttendeesVM model)
        {
            return await _service.Update(model);
        }

        /// <summary>
        /// لیست حاضرین جلسه
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAll))]
        public async Task<Result<PagingResultVM<DepartmentMeetingAttendeesResultVM>>> GetAll([FromQuery] DepartmentMeetingAttendeesSearchVM search)
        {
            return await _service.GetAll(search);
        }

        /// <summary>
        /// لیست اعضاء جلسه
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetAllMembers))]
        public async Task<Result<List<DepartmentMeetingAttendeesResultVM>>> GetAllMembers([FromBody] int id)
        {
            return await _service.GetAllMembers(id);
        }

        /// <summary>
        /// لیست اعضاء حاضر
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Collection))]
        public async Task<Result<List<CollectionVM>>> Collection([FromBody] int? id)
        {
            return await _service.Collection(id);
        }
    }
}
