using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.BaseInfo;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.Staffs;
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
    /// تخصیص سمت به پرسنل 
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class AssignPositionController : ApiBaseController
    {
        private readonly IAssignPositionService _assignPositionService;
        public AssignPositionController(IAssignPositionService assignPositionService)
        {
            _assignPositionService = assignPositionService;
        }

        /// <summary>
        /// حذف تخصیص سمت به پرسنل
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.AssignPositionDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _assignPositionService.Delete(id);
        }

        /// <summary>
        /// افزودن تخصیص سمت به پرسنل جدید
        /// </summary>
        /// <param name="assignPosition"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.AssignPositionAdd)]
        public async Task<Result<bool>> Add([FromBody] AssignPositionVM assignPosition)
        {
            return await _assignPositionService.Add(assignPosition);
        }

        /// <summary>
        /// آماده سازی ویرایش تخصیص سمت به پرسنل
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetById")]
        [AdminAuthorize((int)AdminAuthorize.AssignPositionEdit)]
        public async Task<Result<List<AssignPositionVM>>> GetById([FromBody] int id)
        {
            var result = await _assignPositionService.GetById(id);
            return result;
        }

       
        /// <summary>
        /// لیست تخصیص سمت به پرسنل 
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.AssignPositionManagement)]
        public async Task<Result<List<AssignPositionVM>>> GetAll()
        {
            return await _assignPositionService.GetAll();
        }


        /// <summary>
        /// آماده سازی افزودن سمت به پرسنل
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetAllPositions")]
        [AdminAuthorize((int)AdminAuthorize.RolesAdd)]
        public async Task<Result<Root>> GetAllPositions()
        {
            var result = await _assignPositionService.GetAllPositions();
            return result;
        }

        /// <summary>
        /// ویراتیش تخصیص سمت به پرسنل جدید
        /// </summary>
        /// <param name="assignPosition"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.AssignPositionAdd)]
        public async Task<Result<bool>> Update([FromBody] AssignPositionVM assignPosition)
        {
            return await _assignPositionService.Update(assignPosition);
        }
    }
}
