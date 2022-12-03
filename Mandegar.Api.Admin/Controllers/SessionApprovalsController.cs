using Mandegar.CoreBase.Controller;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.SessionApproval;
using Mandegar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    /// <summary>
    /// مصوبات جلسه
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class SessionApprovalsController : ApiBaseController
    {
        private readonly ISessionApprovalsService _service;
        public SessionApprovalsController(ISessionApprovalsService service)
        {
            _service = service;
        }

        /// <summary>
        /// حذف مصوبات جلسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Delete))]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _service.Delete(id);
        }

        /// <summary>
        /// افزودن مصوبات جلسه
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Add))]
        public async Task<Result<bool>> Add([FromBody] SessionApprovalVM model)
        {
            return await _service.Add(model);
        }

        /// <summary>
        /// دریافت مصوبات جلسه بر اساس شناسه جلسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Get))]
        public async Task<Result<SessionApprovalVM>> Get([FromBody] int id)
        {
            return await _service.GetById(id);
        }

        /// <summary>
        /// بروز رسانی مصوبات جلسه
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Update))]
        public async Task<Result<bool>> Update([FromBody] SessionApprovalVM model)
        {
            return await _service.Update(model);
        }

        /// <summary>
        /// لیست مصوبات جلسه
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAll))]
        public async Task<Result<PagingResultVM<SessionApprovalResultVM>>> GetAll([FromQuery] SessionApprovalSearchVM search)
        {
            return await _service.GetAll(search);
        }

        /// <summary>
        /// لیست اعضاء دپارتمان پیگیری
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(GetAllMembers))]
        public async Task<Result<List<SessionApprovalResultVM>>> GetAllMembers([FromBody] int id)
        {
            return await _service.GetAllMembers(id);
        }
    }
}
