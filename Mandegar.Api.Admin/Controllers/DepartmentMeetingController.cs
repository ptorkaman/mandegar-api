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
    /// برگزاری جلسه
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentMeetingController : ApiBaseController
    {
        private readonly IDepartmentMeetingService _service;
        public DepartmentMeetingController(IDepartmentMeetingService service)
        {
            _service = service;
        }

        /// <summary>
        /// حذف جلسه
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
        public async Task<Result<bool>> Add([FromBody] DepartmentMeetingVM model)
        {
            return await _service.Add(model);
        }

        /// <summary>
        /// دریافت جلسه بر اساس شناسه جلسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Get))]
        public async Task<Result<DepartmentMeeting>> Get([FromBody] int id)
        {
            return await _service.GetById(id);
        }

        /// <summary>
        /// بروز رسانی جلسه
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Update))]
        public async Task<Result<bool>> Update([FromBody] DepartmentMeetingVM model)
        {
           return await _service.Update(model);
        }

        /// <summary>
        /// لیست جلسه ها
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAll))]
        public async Task<Result<PagingResultVM<DepartmentMeeting>>> GetAll([FromQuery] DepartmentMeetingSearchVM search)
        {
            return await _service.GetAll(search);
        }

        /// <summary>
        /// عناوین جلسه ها
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Collection))]
        public async Task<Result<List<CollectionVM>>> Collection()
        {
            return await _service.Collection();
        }
    }
}
