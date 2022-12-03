using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Departments;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.EvaluationIndicator;
using Mandegar.Models.ViewModels.Shared;
using Mandegar.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    /// <summary>
    /// شاخص ارزشيابي
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationIndicatorController : ApiBaseController
    {
        private readonly IEvaluationIndicatorService _service;
        public EvaluationIndicatorController(IEvaluationIndicatorService service)
        {
            _service = service;
        }

        /// <summary>
        /// حذف شاخص ارزشيابي
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Delete))]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _service.Delete(id);
        }

        /// <summary>
        /// افزودن شاخص ارزشيابي
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Add))]
        public async Task<Result<bool>> Add([FromBody] EvaluationIndicatorVM model)
        {
            return await _service.Add(model);
        }

        /// <summary>
        /// دریافت شاخص ارزشيابي بر اساس شناسه
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Get))]
        public async Task<Result<EvaluationIndicator>> Get([FromBody] int id)
        {
            return await _service.GetById(id);
        }

        /// <summary>
        /// بروز رسانی شاخص ارزشيابي
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Update))]
        public async Task<Result<bool>> Update([FromBody] EvaluationIndicatorVM model)
        {
            return await _service.Update(model);
        }

        /// <summary>
        /// لیست شاخص های ارزشيابي
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAll))]
        public async Task<Result<PagingResultVM<EvaluationIndicatorResultVM>>> GetAll([FromQuery] EvaluationIndicatorSearchVM search)
        {
            return await _service.GetAll(search);
        }

        /// <summary>
        /// دپارتمان درس
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Collection))]
        public async Task<Result<List<CollectionVM>>> Collection()
        {
            return await _service.Collection();
        }
    }
}
