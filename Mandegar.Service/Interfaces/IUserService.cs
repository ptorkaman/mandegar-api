using Mandegar.Models.Entities.User;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Account;
using Mandegar.Models.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Interfaces
{
    public interface IUserService
    {
        Task<Result<bool>> Add(CreateUserVM request);
        Task<Result<bool>> Update(CreateUserVM request);
        Task<Result<bool>> ChangePassword(AdminChangePasswordVM model);
        Task<Result<CreateUserVM>> CreatePreparation();
        Task<Result<UpdateUserVM>> UpdatePreparation(int id);
        Task<Result<bool>> Delete(int id);
        Task<Result<bool>> UpdateProfile(CreateUserVM request);
        Task<Result<bool>> LogOut();
        Task<Result<bool>> Register(RegisterUserFormVM user);
        Task<Result<bool>> ConfirmRegistration(string id);
        Task<Result<bool>> ForgotPassword(ForgotPasswordVM forgotPasswordModel);
        Task<Result<bool>> GetResetPassword(string id);
        Task<Result<bool>> ResetPassword(ResetPasswordVM resetPassword);
        Task<Result<bool>> HasAccess(int roleId);
        Task<Result<TokenVM>> GetToken(LoginFormVM login);
        Task<Result<string>> GetUserAvatar();
        Task<Result<User>> Get(int Id);
        Task<Result<List<User>>> GetAll();
        Task<Result<PagingResultVM<UserListResultVM>>> Search(UserSearchVM search);
    }
}
