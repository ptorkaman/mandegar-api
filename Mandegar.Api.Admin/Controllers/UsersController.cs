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
    /// کاربران
    /// </summary>
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UsersController : ApiBaseController
    {
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }

        /// <summary>
        /// حذف کاربر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Delete")]
        [AdminAuthorize((int)AdminAuthorize.UserDelete)]
        public async Task<Result<bool>> Delete([FromBody] int id)
        {
            return await _userService.Delete(id);
        }

        /// <summary>
        /// افزودن کاربر
        /// </summary>
        /// <returns></returns>
        [HttpPost("Add")]
        [AdminAuthorize((int)AdminAuthorize.UserAdd)]
        public async Task<Result<bool>> Add([FromBody] CreateUserVM request)
        {
            return await _userService.Add(request);
        }

        /// <summary>
        /// تغییر رمز عبور
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost("ChangePassword")]
        [AdminAuthorize((int)AdminAuthorize.PanelAdmin)]
        public async Task<Result<bool>> ChangePassword([FromBody] AdminChangePasswordVM model)
        {
            return await _userService.ChangePassword(model);
        }

        /// <summary>
        /// دریافت کاربر بر اساس شناسه کاربر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost("Get")]
        [AdminAuthorize((int)AdminAuthorize.UserEdit)]
        public async Task<Result<User>> Get([FromBody] int id)
        {
            return await _userService.Get(id);
        }

        /// <summary>
        /// بروز رسانی کاربر
        /// </summary>
        /// <returns></returns>
        [HttpPost("Update")]
        [AdminAuthorize((int)AdminAuthorize.UserEdit)]
        public async Task<Result<bool>> Update([FromBody] CreateUserVM request)
        {
            var result = await _userService.Update(request);
            return result;
        }

        /// <summary>
        /// دریافت اطلاعات پروفایل
        /// </summary>
        /// <param name=""></param>
        /// <returns></returns>
        [HttpGet("GetProfile")]
        [AdminAuthorize((int)AdminAuthorize.PanelAdmin)]
        public async Task<Result<UpdateUserVM>> GetProfile()
        {
            return await _userService.UpdatePreparation(UserId);
        }

        /// <summary>
        /// ویرایش پروفایل
        /// </summary>
        /// <returns></returns>
        [HttpPost("UpdateProfile")]
        [AdminAuthorize((int)AdminAuthorize.PanelAdmin)]
        public async Task<Result<bool>> UpdateProfile([FromBody] CreateUserVM request)
        {
            return await _userService.UpdateProfile(request);
        }

        /// <summary>
        /// دریافت آواتار کاربر
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetUserAvatar")]
        [AdminAuthorize((int)AdminAuthorize.PanelAdmin)]
        public async Task<Result<string>> GetUserAvatar()
        {
            return await _userService.GetUserAvatar();
        }

        /// <summary>
        /// لیست کاربر ها
        /// </summary>
        /// <returns></returns>
        [HttpGet("GetAll")]
        [AdminAuthorize((int)AdminAuthorize.UserManagement)]
        public async Task<Result<PagingResultVM<UserListResultVM>>> GetAll([FromQuery] UserSearchVM search)
        {
            return await _userService.Search(search);
        }

        /// <summary>
        /// آماده سازی ویرایش کاربر
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("UpdatePreparation")]
        [AdminAuthorize((int)AdminAuthorize.UserEdit)]
        public async Task<Result<UpdateUserVM>> UpdatePreparation(int id)
        {
            var result = await _userService.UpdatePreparation(id);
            return result;
        }
    }
}
