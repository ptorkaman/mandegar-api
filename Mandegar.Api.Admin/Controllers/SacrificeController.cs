using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Sacrifices;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.ActionFilters;
using Mandegar.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class SacrificeController : ApiBaseController
    {
        private readonly ISacrificeService _sacrificeService;

        public SacrificeController(ISacrificeService sacrificeService)
        {
            _sacrificeService = sacrificeService;
        }

        /// <summary>
        /// دریافت ایثارگری
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<SacrificeVM>> Get([FromQuery] int staffId)
        {
            return await _sacrificeService.Get(staffId);
        }

        /// <summary>
        /// ویرایش ایثارگری
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Update(SacrificeVM model)
        {
            return await _sacrificeService.Update((Sacrifice)model);

        }
    }
}
