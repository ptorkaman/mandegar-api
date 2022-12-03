using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.Personeli;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.StaffFamily;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.ActionFilters;
using Mandegar.Utilities.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Api.Admin.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class StaffFamilyInformationController : ApiBaseController
    {
        private readonly IStaffFamilyInformationService _staffFamilyInformationService;

        public StaffFamilyInformationController(IStaffFamilyInformationService staffFamilyInformationService)
        {
            _staffFamilyInformationService = staffFamilyInformationService;
        }

        /// <summary>
        /// دریافت اطلاعات خانواده
        /// </summary>
        /// <returns></returns>
        [HttpGet("Get")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<StaffFamilyInformationVM>> Get([FromQuery] int id)
        {
            return await _staffFamilyInformationService.Get(id);
        }

        /// <summary>
        /// افزودن اطلاعات خانواده
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Add(StaffFamilyInformationVM model)
        {
            return await _staffFamilyInformationService.Add((StaffFamilyInformation)model);
        }

        /// <summary>
        /// ویرایش اطلاعات خانواده
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Update(StaffFamilyInformationVM model)
        {
            return await _staffFamilyInformationService.Update((StaffFamilyInformation)model);

        }

        /// <summary>
        /// حذف اطلاعات خانواده
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _staffFamilyInformationService.Delete(id);
        }

        /// <summary>
        /// دریافت اطلاعات خانواده
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.StaffManagement)]
        public async Task<Result<List<StaffFamilyInformationVM>>> GetAll([FromQuery] int staffId)
        {
            return await _staffFamilyInformationService.GetAll(staffId);
        }
    }
}
