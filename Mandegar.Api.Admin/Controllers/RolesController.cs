using Mandegar.CoreBase.Controller;
using Mandegar.Models.Entities.User;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Account;
using Mandegar.Models.ViewModels.Common;
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
    /// نقش ها
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class RolesController : ApiBaseController
    {
        private readonly IRoleService _roleService;
        public RolesController(IRoleService roleService)
        {
            _roleService = roleService;
        }

        /// <summary>
        /// حذف نقش
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.RolesDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _roleService.Delete(id);
        }

        /// <summary>
        /// آماده سازی افزودن نقش
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("CreatePreparation")]
        [AdminAuthorize((int)AdminAuthorize.RolesAdd)]
        public async Task<Result<CreateRoleVM>> CreatePreparation()
        {
            var result = await _roleService.CreatePreparation();
            return result;
        }

        /// <summary>
        /// آماده سازی افزودن نقش
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("GetAllPermissions")]
        [AdminAuthorize((int)AdminAuthorize.RolesAdd)]
        public async Task<Result<Root>> GetAllPermissions()
        {
            var result = await _roleService.GetAllPermissionsAsync();
            return result;
        }

        /// <summary>
        /// افزودن نقش جدید
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.RolesAdd)]
        public async Task<Result<bool>> Add([FromBody] Role role)
        {
            return await _roleService.Add(role);
        }

        /// <summary>
        /// آماده سازی ویرایش نقش
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("UpdatePreparation")]
        [AdminAuthorize((int)AdminAuthorize.RolesEdit)]
        public async Task<Result<CreateRoleVM>> UpdatePreparation([FromBody] int id)
        {
            var result = await _roleService.UpdatePreparation(id);
            return result;
        }

        /// <summary>
        /// بروز رسانی نقش
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.RolesEdit)]
        public async Task<Result<bool>> Update([FromBody] Role role)
        {
            var result = await _roleService.Update(role);
            return result;
        }

        /// <summary>
        /// لیست نقش ها
        /// </summary>
        /// <returns></returns>
        [HttpPost("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.RolesManagement)]
        public async Task<Result<List<Role>>> GetAll()
        {
            return await _roleService.GetAll();
        }
    }
}
