using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffAddresses;
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
    public class StaffAddressController : ApiBaseController
    {
        private readonly IStaffAddressService _staffAddressService;

        public StaffAddressController(IStaffAddressService staffAddressService)
        {
            _staffAddressService = staffAddressService;
        }

        /// <summary>
        /// دریافت آدرس
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<StaffAddressVM>> Get([FromQuery] int staffId)
        {
            return await _staffAddressService.Get(staffId);
        }

        /// <summary>
        /// ویرایش آدرس
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Update(StaffAddressVM model)
        {
            return await _staffAddressService.Update((StaffAddress)model);

        }
    }
}
