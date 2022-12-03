using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Departments;
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
    /// اعضاء جلسه
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentMeetingMemberController : ApiBaseController
    {
        private readonly IDepartmentMeetingMember _service;
        public DepartmentMeetingMemberController(IDepartmentMeetingMember service)
        {
            _service = service;
        }

        /// <summary>
        /// حذف جلسه دپارتمان
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Delete))]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _service.Delete(id);
        }

        /// <summary>
        /// افزودن جلسه
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Add))]
        public async Task<Result<bool>> Add([FromBody] MeetingMemberVM model)
        {
            return await _service.Add(model);
        }

        /// <summary>
        /// دریافت جلسه بر اساس شناسه جلسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Get))]
        public async Task<Result<MeetingMemberVM>> Get([FromBody] int id)
        {
            return await _service.GetById(id);
        }

        /// <summary>
        /// دریافت اعضاء جلسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(GetAllMembers))]
        public async Task<Result<List<DepartmentStaffVM>>> GetAllMembers([FromBody] int id)
        {
            return await _service.GetAllMembers(id);
        }

        /// <summary>
        /// بروز رسانی جلسه
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Update))]
        public async Task<Result<bool>> Update([FromBody] MeetingMemberVM model)
        {
            return await _service.Update(model);
        }

        /// <summary>
        /// لیست جلسه ها
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAll))]
        public async Task<Result<PagingResultVM<DepartmentMeetingMemberVM>>> GetAll([FromQuery] DepartmentMeetingMemberSearchVM model)
        {
            return await _service.GetAll(model);
        }

        /// <summary>
        /// لیست اعضاء
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Collection))]
        public async Task<Result<List<CollectionVM>>> Collection([FromBody] int? id)
        {
            return await _service.Collection(id);
        }
    }
}
