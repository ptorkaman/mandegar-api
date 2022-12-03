using Mandegar.CoreBase.Controller;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.DepartmentMeeting;
using Mandegar.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    /// <summary>
    /// صورت جلسه
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    public class ProceedingsDepartmentController : ApiBaseController
    {
        private readonly IProceedingsDepartmentService _service;
        public ProceedingsDepartmentController(IProceedingsDepartmentService service)
        {
            _service = service;
        }

        /// <summary>
        /// حذف صورتجلسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Delete))]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _service.Delete(id);
        }

        /// <summary>
        /// افزودن صورتجلسه
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Add))]
        public async Task<Result<bool>> Add([FromBody] ProceedingsDepartmentVM model)
        {
            return await _service.Add(model);
        }

        /// <summary>
        /// دریافت صورتجلسه بر اساس شناسه صورتجلسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Get))]
        public async Task<Result<ProceedingsDepartmentVM>> Get([FromBody] int id)
        {
            return await _service.GetById(id);
        }

        /// <summary>
        /// بروز رسانی صورتجلسه
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Update))]
        public async Task<Result<bool>> Update([FromBody] ProceedingsDepartmentVM model)
        {
            return await _service.Update(model);
        }

        /// <summary>
        /// لیست صورتجلسه ها
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAll))]
        public async Task<Result<PagingResultVM<ProceedingsDepartmentVM>>> GetAll([FromQuery] ProceedingsDepartmentSearchVM model)
        {
            return await _service.GetAll(model);
        }
    }
}
