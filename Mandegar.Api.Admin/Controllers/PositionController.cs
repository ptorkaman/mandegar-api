using Mandegar.CoreBase.Controller;
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
    /// سمت 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class PositionController : ApiBaseController
    {
        private readonly IPositionService _positionService;
        public PositionController(IPositionService positionService)
        {
            _positionService = positionService;
        }

        /// <summary>
        /// حذف سمت
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.PositionDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _positionService.Delete(id);
        }

        

        /// <summary>
        /// افزودن سمت جدید
        /// </summary>
        /// <param name="position"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.TaskAdd)]
        public async Task<Result<bool>> Add([FromBody] PositionVM position)
        {
            return await _positionService.Add(position);
        }

        /// <summary>
        /// آماده سازی ویرایش سمت
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.PositionEdit)]
        public async Task<Result<PositionVM>> GetById([FromBody] int id)
        {
            var result = await _positionService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی سمت
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.PositionEdit)]
        public async Task<Result<bool>> Update([FromBody] PositionVM position)
        {
            var result = await _positionService.Update(position);
            return result;
        }

        /// <summary>
        /// لیست سمت ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.PositionManagement)]
        public async Task<Result<List<PositionVM>>> GetAll()
        {
            return await _positionService.GetAll();
        }
    }
}
