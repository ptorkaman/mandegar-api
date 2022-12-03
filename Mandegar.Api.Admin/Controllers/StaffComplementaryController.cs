using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffComplementaries;
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
    public class StaffComplementaryController : ApiBaseController
    {
        private readonly IStaffComplementaryService _StaffComplementaryService;

        public StaffComplementaryController(IStaffComplementaryService StaffComplementaryService)
        {
            _StaffComplementaryService = StaffComplementaryService;
        }

        /// <summary>
        /// دریافت اطلاعات تکمیلی
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<StaffComplementaryVM>> Get([FromQuery] int staffId)
        {
            return await _StaffComplementaryService.Get(staffId);
        }

        /// <summary>
        /// ویرایش اطلاعات تکمیلی
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Update(StaffComplementaryVM model)
        {
            return await _StaffComplementaryService.Update((StaffComplementary)model);

        }
    }
}
