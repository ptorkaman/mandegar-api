using Mandegar.CoreBase.Controller;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.EvaluationGroup;
using Mandegar.Models.ViewModels.Shared;
using Mandegar.Services.Impeliments;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EvaluationGroupController : ApiBaseController
    {
        private readonly IEvaluationGroupService _service;
        public EvaluationGroupController(IEvaluationGroupService service)
        {
            _service = service;
        }

        /// <summary>
        /// حذف گروه ارزشيابي
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Delete))]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _service.Delete(id);
        }

        /// <summary>
        /// افزودن گروه ارزشيابي
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Add))]
        public async Task<Result<bool>> Add([FromBody] EvaluationGroupVM model)
        {
            return await _service.Add(model);
        }

        /// <summary>
        /// دریافت گروه ارزشيابي بر اساس شناسه گروه ارزشيابي
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost(nameof(Get))]
        public async Task<Result<EvaluationGroupResultVM>> Get([FromBody] int id)
        {
            return await _service.GetById(id);
        }

        /// <summary>
        /// بروز رسانی گروه ارزشيابي
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Update))]
        public async Task<Result<bool>> Update([FromBody] EvaluationGroupVM model)
        {
            return await _service.Update(model);
        }

        /// <summary>
        /// لیست گروه ارزشيابي
        /// </summary>
        /// <returns></returns>
        [HttpGet(nameof(GetAll))]
        public async Task<Result<PagingResultVM<EvaluationGroupResultVM>>> GetAll([FromQuery] EvaluationGroupSearchVM model)
        {
            return await _service.GetAll(model);
        }

        /// <summary>
        /// عناوین گروه ارزشیابی
        /// </summary>
        /// <returns></returns>
        [HttpPost(nameof(Collection))]
        public async Task<Result<List<CollectionVM>>> Collection()
        {
            return await _service.Collection();
        }
    }
}
