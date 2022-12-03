using Mandegar.CoreBase.Controller;
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
    /// نوع همکاری 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class CooperationTypeController : ApiBaseController
    {
        private readonly ICooperationTypeService _cooperationTypeService;
        public CooperationTypeController(ICooperationTypeService cooperationTypeService)
        {
            _cooperationTypeService = cooperationTypeService;
        }

        /// <summary>
        /// حذف نوع همکاری
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.CooperationTypeDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _cooperationTypeService.Delete(id);
        }

       

        /// <summary>
        /// افزودن نوع همکاری جدید
        /// </summary>
        /// <param name="cooperationType"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.CooperationTypeAdd)]
        public async Task<Result<bool>> Add([FromBody] CooperationTypeVM cooperationType)
        {
            return await _cooperationTypeService.Add(cooperationType);
        }

        /// <summary>
        /// آماده سازی ویرایش نوع همکاری
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.CooperationTypeEdit)]
        public async Task<Result<CooperationTypeVM>> GetById([FromBody] int id)
        {
            var result = await _cooperationTypeService.GetById(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی نوع همکاری
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.CooperationTypeEdit)]
        public async Task<Result<bool>> Update([FromBody] CooperationTypeVM cooperationType)
        {
            var result = await _cooperationTypeService.Update(cooperationType);
            return result;
        }

        /// <summary>
        /// لیست نوع همکاری ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.CooperationTypeManagement)]
        public async Task<Result<List<CooperationType>>> GetAll()
        {
            return await _cooperationTypeService.GetAll();
        }
    }
}
