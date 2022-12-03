using Mandegar.Models.Entities.User;
using Mandegar.Models.HelperModels;
using Mandegar.Models.ViewModels.Account;
using Mandegar.Models.ViewModels.Common;
using Mandegar.Models.ViewModels.Roles;
using Mandegar.Models.ViewModels.StoreProcedures.Account;
using Mandegar.Repository.UnitOfWork;
using Mandegar.Resources.AdminMessage;
using Mandegar.Services.Interfaces;
using Mandegar.Utilities.BusinessHelpers;
using Mandegar.Utilities.Enums;
using Mandegar.Utilities.Extensions;
using Mandegar.Utilities.Interfaces;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Security = Mandegar.Utilities.BusinessHelpers.Security;


namespace Mandegar.Services.Impeliments
{
    public class UserService : IUserService
    {
        private readonly IUow _uow;
        private readonly IRoleService _roleService;
        private readonly IFileManager _fileManager;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ISendEmailService _sendEmail;
        private readonly IViewRenderService _viewRenderService;
        public UserService(IUow uow, IRoleService roleService, IFileManager fileManager, IHttpContextAccessor httpContextAccessor,
            ISendEmailService sendEmail, IViewRenderService viewRenderService)
        {

            _uow = uow;
            _roleService = roleService;
            _fileManager = fileManager;
            _httpContextAccessor = httpContextAccessor;
            _sendEmail = sendEmail;
            _viewRenderService = viewRenderService;
        }

        public async Task<Result<bool>> Add(CreateUserVM request)
        {
            try
            {
                #region Check Required Values

                if (string.IsNullOrWhiteSpace(request.User?.Username) ||
                           string.IsNullOrWhiteSpace(request.User?.Password) ||
                           string.IsNullOrWhiteSpace(request.Profile?.Email))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }

                #endregion

                #region Check If Username or Email is Exist
                if (await _uow.GetRepository<User>().Get(c => c.Username == request.User.Username).AnyAsync())
                {
                    return new Result<bool>(Messages.DuplicateUsername);
                }

                if (await _uow.GetRepository<User>().GetWithInclude(c => c.Profile).Where(c => c.Profile.Email == request.Profile.Email).AnyAsync())
                {
                    return new Result<bool>(Messages.DuplicateEmail);
                }
                #endregion

                #region Check Password Is Not Empty

                if (string.IsNullOrWhiteSpace(request.User.Password))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }

                #endregion

                #region Roles
                foreach (var item in request.Roles)
                {
                    request.User.UserRoles = new List<UserRole>();
                    request.User.UserRoles.Add(new UserRole()
                    {
                        User = request.User,
                        RoleId = item.Id
                    });
                }

                #endregion

                request.User.RequestCode = Security.Encrypt(Guid.NewGuid().ToString("N"));
                request.User.Profile = request.Profile;
                request.User.Password = Security.Encrypt(request.User.Password);

                try
                {

                    #region Upload Avatar
                    if (string.IsNullOrWhiteSpace(request.UserAvatar) == false)
                    {
                        request.UserAvatar = request.UserAvatar.ReplaceBase64();

                        byte[] imageBytes = Convert.FromBase64String(request.UserAvatar);

                        var upload = await _fileManager.UploadFile(imageBytes, DefaultPath.UserAvatar, FileType.Images);
                        if (upload.Success)
                        {
                            _fileManager.ImageResizer(upload.Data.ToString(), DefaultPath.UserAvatar, 80);
                            request.Profile.Avatar = upload.Data.ToString();
                        }
                        else
                        {
                            return new Result<bool>(upload.Message);
                        }
                    }
                    else
                    {
                        request.Profile.Avatar = "/Images/UserAvatar/Default.jpg";
                    }
                    #endregion

                    await _uow.GetRepository<User>().AddAsync(request.User);
                    await _uow.SaveChangesAsync();

                    return new Result<bool>(true);
                }
                catch (Exception ex)
                {
                    _fileManager.RemoveFile(request.Profile.Avatar, DefaultPath.UserAvatar, FileType.Images);
                    return new Result<bool>(false);

                }
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<bool>> ChangePassword(AdminChangePasswordVM model)
        {

            try
            {
                if (string.IsNullOrWhiteSpace(model.currentPassword) || string.IsNullOrWhiteSpace(model.newPassword))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }

                model.UserId = ClaimHelper.GetUserId();
                var user = await _uow.GetRepository<User>().Get(model.UserId);
                if (user == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                var userPassword = user.Password;

                if (!string.IsNullOrWhiteSpace(userPassword))
                {
                    if (userPassword != Security.Encrypt(model.currentPassword))
                    {
                        return new Result<bool>(Messages.WrongPassword);
                    }

                    user.Password = Security.Encrypt(model.newPassword);
                    user.ModifiedOn = DateTime.Now;

                    _uow.GetRepository<User>().Update(user);
                    await _uow.SaveChangesAsync();

                    return new Result<bool>(true);
                }

                return new Result<bool>(false);

            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<bool>> ConfirmRegistration(string id)
        {

            try
            {
                #region Check Id Is Not Null

                if (string.IsNullOrWhiteSpace(id))
                {
                    return new Result<bool>(false);
                }

                #endregion

                #region Get User ActiveCode
                id = Security.Decrypt(id);
                var user = await _uow.GetRepository<User>().Get(c => c.RequestCode == TextHelper.TolowerTrimText(id)).FirstOrDefaultAsync();
                #endregion

                #region Check If Activecode is Null
                if (user == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                #endregion

                #region Active User
                user.IsActive = true;
                #endregion

                #region Change User ActiveCode
                user.RequestCode = Generator.UniqueNameGenerator();
                #endregion

                _uow.GetRepository<User>().Update(user);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);
            }

            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<CreateUserVM>> CreatePreparation()
        {
            try
            {
                var model = new CreateUserVM();
                var roles = await _roleService.GetAll();
                if (!roles.Success)
                {
                    return new Result<CreateUserVM>(false);
                }

                model.Roles = roles.Data;

                return new Result<CreateUserVM>(model);

            }
            catch (Exception ex)
            {
                return new Result<CreateUserVM>(false);
            }
        }

        public async Task<Result<bool>> Delete(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                var model = _uow.GetRepository<User>().Get(c => c.Id == id).FirstOrDefault();
                if (model == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                model.IsDeleted = true;
                _uow.GetRepository<User>().Update(model);
                await _uow.SaveChangesAsync();

                return new Result<bool>(true);

            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<bool>> ForgotPassword(ForgotPasswordVM forgotPasswordModel)
        {
            try
            {
                #region Check ModelState
                if (string.IsNullOrWhiteSpace(forgotPasswordModel.Email))
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                #endregion

                #region Get User ActiveCode
                var activeCode = "";
                var user = await _uow.GetRepository<User>().GetWithInclude(c => c.Profile).Where(c => c.Profile.Email == TextHelper.TolowerTrimText(forgotPasswordModel.Email)).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                activeCode = Security.Encrypt(user.RequestCode);
                #endregion

                #region Check If Activecode is Null
                if (string.IsNullOrWhiteSpace(activeCode))
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                #endregion

                #region Send Activation Code
                var model = new EmailUserActiveCodeVM();
                model.Email = forgotPasswordModel.Email;
                model.ActiveCode = activeCode;
                model.Domain = AppsettingsGetter.Get("UiSettings:url");

                var body = _viewRenderService.RenderToStringAsync("_SendEmailForgotPassword", model);


                _ = _sendEmail.SendAsync(model.Email, "بازیابی رمز عبور", body);
                #endregion

                return new Result<bool>(true);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }

        }

        public async Task<Result<User>> Get(int Id)
        {
            try
            {
                var data = await _uow.GetRepository<User>().Get(Id);

                return new Result<User>(data);
            }
            catch (Exception)
            {
                return new Result<User>(false);
            }
        }

        public async Task<Result<bool>> LogOut()
        {
            try
            {
                if (_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    await _httpContextAccessor.HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
                    return new Result<bool>(true);
                }
                return new Result<bool>(false);
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<bool>> Register(RegisterUserFormVM user)
        {
            try
            {
                #region Validation

                if (string.IsNullOrWhiteSpace(user.Email) || string.IsNullOrWhiteSpace(user.Password) || string.IsNullOrWhiteSpace(user.RePassword))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }

                #endregion

                #region Check Email Exists

                var isEmailExist = await _uow.GetRepository<User>().GetWithInclude(c => c.Profile).Where(c => c.Profile.Email == user.Email).AnyAsync();
                if (isEmailExist)
                {
                    return new Result<bool>(Messages.DuplicateEmail);
                }

                #endregion

                #region Create User And Insert in DB

                var newUser = new User();
                newUser.UserRoles = new List<UserRole>();
                var profile = new Profile();

                var activeCode = Security.Encrypt(Guid.NewGuid().ToString("N"));

                profile.Email = user.Email.Trim();
                newUser.Username = user.Email.Trim();
                newUser.Password = Security.Encrypt(user.Password);
                newUser.IsActive = false;
                newUser.RequestCode = activeCode;

                newUser.Profile = profile;
                newUser.UserRoles.Add(new UserRole() { User = newUser, RoleId = -1 });

                await _uow.GetRepository<User>().AddAsync(newUser);
                await _uow.SaveChangesAsync();

                #endregion

                #region Send Activation Code

                try
                {
                    var model = new EmailUserActiveCodeVM();
                    model.Email = user.Email;
                    model.ActiveCode = activeCode;
                    model.Domain = AppsettingsGetter.Get("UiSettings:url");

                    var body = _viewRenderService.RenderToStringAsync("_SendEmailConfirmRegisteration", model);

                    _sendEmail.SendAsync(model.Email, "تائید عضویت", body);
                }
                catch (Exception)
                {
                    return new Result<bool>(true);

                }
                #endregion

                return new Result<bool>(true);

            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }

        }

        public async Task<Result<bool>> GetResetPassword(string id)
        {
            try
            {
                #region Check If Id IsNullOrWhiteSpace
                if (string.IsNullOrWhiteSpace(id))
                {
                    return new Result<bool>(Messages.RequestInvalid);
                }
                #endregion

                #region Check If ActiveCode is Eixists
                id = Security.Decrypt(id);
                var user = await _uow.GetRepository<User>().Get(c => c.RequestCode == id).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new Result<bool>(Messages.RequestInvalid);
                }
                #endregion
            }

            catch (Exception ex)
            {
                return new Result<bool>(false);

            }
            return new Result<bool>(true);
        }

        public async Task<Result<UpdateUserVM>> UpdatePreparation(int id)
        {
            try
            {
                if (id == 0)
                {
                    return new Result<UpdateUserVM>(Messages.NotExistsData);
                }

                var model = new UpdateUserVM();
                var user = await _uow.GetRepository<User>().GetWithInclude(new string[] { "Profile", "UserRoles", "UserRoles.Role" })
                    .Where(c => c.Id == id)
                    .AsNoTracking()
                    .FirstOrDefaultAsync();
                if (user == null)
                {
                    return new Result<UpdateUserVM>(Messages.NotExistsData);
                }

                if (user.Profile.Avatar.ToLower().EndsWith("default.jpg"))
                {
                    model.UserAvatar = await _fileManager.GetImageAsBase64String("Default.jpg", DefaultPath.DefultUserAvatar);
                }
                else
                {
                    model.UserAvatar = await _fileManager.GetImageAsBase64String(user.Profile.Avatar, DefaultPath.UserAvatar);
                }

                model.Roles = user.UserRoles.Select(c => c.Role).Select(c => (RoleVM)c).ToList();
                model.Profile = (ProfileVM)user.Profile;
                model.User = (UserVM)user;

                return new Result<UpdateUserVM>(model);

            }
            catch (Exception ex)
            {
                return new Result<UpdateUserVM>(false);
            }
        }

        public async Task<Result<bool>> UpdateProfile(CreateUserVM request)
        {
            try
            {
                #region Check If userId is not Null!
                request.User.Id = ClaimHelper.GetUserId();

                if (request.User.Id == 0)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                #endregion

                #region Check If User Is Null

                var currentUser = await _uow.GetRepository<User>()
                    .GetWithInclude(c => c.Profile, c => c.UserRoles)
                    .Where(c => c.Id == request.User.Id).FirstOrDefaultAsync();
                if (currentUser == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                #endregion

                #region Check If Username or Email is Exist

                if (await _uow.GetRepository<User>().Get(c => c.Id != request.User.Id && c.Username == request.User.Username).AnyAsync())
                {
                    return new Result<bool>(Messages.DuplicateUsername);
                }

                if (await _uow.GetRepository<User>().GetWithInclude(c => c.Profile).Where(c => c.Id != request.User.Id && c.Profile.Email == request.Profile.Email).AnyAsync())
                {
                    return new Result<bool>(Messages.DuplicateEmail);
                }

                #endregion

                try
                {

                    #region Upload Avatar

                    if (string.IsNullOrWhiteSpace(request.UserAvatar) == false)
                    {
                        request.UserAvatar = request.UserAvatar.ReplaceBase64();

                        byte[] imageBytes = Convert.FromBase64String(request.UserAvatar);


                        if (string.IsNullOrWhiteSpace(request.UserAvatar) == false)
                        {
                            var upload = await _fileManager.UploadFile(imageBytes, DefaultPath.UserAvatar, FileType.Images);
                            if (upload.Success)
                            {
                                if (upload.Success)
                                {
                                    _fileManager.ImageResizer(upload.Data.ToString(), DefaultPath.UserAvatar, 80);
                                    _fileManager.RemoveFile(currentUser.Profile.Avatar, DefaultPath.UserAvatar, FileType.Images);
                                    request.Profile.Avatar = upload.Data.ToString();
                                }
                                else
                                {
                                    return new Result<bool>(upload.Message);
                                }
                            }
                            else
                            {
                                return new Result<bool>(upload.Message);
                            }
                        }
                        else
                        {
                            request.Profile.Avatar = "/Images/UserAvatar/Default.jpg";
                        }
                    }
                    else
                    {
                        request.Profile.Avatar = currentUser.Profile.Avatar;
                    }
                    #endregion

                    currentUser.Username = request.User.Username;

                    if (!string.IsNullOrEmpty(request.User.Password))
                    {
                        currentUser.Password = Security.Encrypt(request.User.Password);
                    }
                    else
                    {
                        currentUser.Password = currentUser.Password;
                    }

                    currentUser.Profile = request.Profile;

                    _uow.GetRepository<User>().Update(currentUser);
                    await _uow.SaveChangesAsync();

                    return new Result<bool>(true);

                }
                catch (Exception ex)
                {
                    _fileManager.RemoveFile(request.Profile.Avatar, DefaultPath.UserAvatar, FileType.Images);
                    return new Result<bool>(false);

                }
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<bool>> Update(CreateUserVM request)
        {
            try
            {
                #region Check If userId is not Null!

                if (request.User.Id == 0)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                #endregion

                #region Check Required Values

                if (string.IsNullOrWhiteSpace(request.User?.Username) ||
                           string.IsNullOrWhiteSpace(request.Profile?.Email))
                {
                    return new Result<bool>(Messages.FillRequredValues);
                }

                #endregion

                #region Check If User Is Null

                var currentUser = await _uow.GetRepository<User>().GetWithInclude(c => c.Profile, c => c.UserRoles).Where(c => c.Id == request.User.Id).FirstOrDefaultAsync();
                if (currentUser == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }

                #endregion

                #region Check If Username or Email is Exist

                if (await _uow.GetRepository<User>().Get(c => c.Id != request.User.Id && c.Username == request.User.Username).AnyAsync())
                {
                    return new Result<bool>(Messages.DuplicateUsername);
                }

                if (await _uow.GetRepository<User>().GetWithInclude(c => c.Profile).Where(c => c.Id != request.User.Id && c.Profile.Email == request.Profile.Email).AnyAsync())
                {
                    return new Result<bool>(Messages.DuplicateEmail);
                }

                #endregion

                try
                {
                    #region Roles


                    foreach (var item in request.Roles)
                    {
                        request.User.UserRoles = new List<UserRole>();
                        request.User.UserRoles.Add(new UserRole()
                        {
                            User = request.User,
                            RoleId = item.Id
                        });
                    }

                    #endregion

                    var oldAvatar = currentUser.Profile.Avatar;

                    #region Upload Avatar

                    if (string.IsNullOrWhiteSpace(request.UserAvatar) == false)
                    {
                        request.UserAvatar = request.UserAvatar.ReplaceBase64();

                        byte[] imageBytes = Convert.FromBase64String(request.UserAvatar);


                        if (string.IsNullOrWhiteSpace(request.UserAvatar) == false)
                        {
                            var upload = await _fileManager.UploadFile(imageBytes, DefaultPath.UserAvatar, FileType.Images);
                            if (upload.Success)
                            {
                                if (upload.Success)
                                {
                                    _fileManager.ImageResizer(upload.Data.ToString(), DefaultPath.UserAvatar, 80);
                                    request.Profile.Avatar = upload.Data.ToString();
                                }
                                else
                                {
                                    return new Result<bool>(upload.Message);
                                }
                            }
                            else
                            {
                                return new Result<bool>(upload.Message);
                            }
                        }
                        else
                        {
                            request.Profile.Avatar = "/Images/UserAvatar/Default.jpg";
                        }
                    }
                    else
                    {
                        request.Profile.Avatar = currentUser.Profile.Avatar;
                    }
                    #endregion

                    currentUser.Username = request.User.Username;
                    currentUser.IsActive = request.User.IsActive;
                    if (!string.IsNullOrEmpty(request.User.Password))
                    {
                        currentUser.Password = Security.Encrypt(request.User.Password);
                    }
                    else
                    {
                        currentUser.Password = currentUser.Password;
                    }

                    currentUser.Profile = request.Profile;

                    currentUser.UserRoles = request.User.UserRoles;
                    currentUser.ModifiedById = ClaimHelper.GetUserId();
                    currentUser.ModifiedOn = DateTime.Now;

                    _uow.GetRepository<User>().Update(currentUser);
                    await _uow.SaveChangesAsync();

                    if (oldAvatar.EndsWith("Default.jpg") == false && string.IsNullOrWhiteSpace(request.UserAvatar) == false)
                    {
                        _fileManager.RemoveFile(oldAvatar, DefaultPath.UserAvatar, FileType.Images);
                    }


                    return new Result<bool>(true);

                }
                catch (Exception ex)
                {
                    _fileManager.RemoveFile(request.Profile.Avatar, DefaultPath.UserAvatar, FileType.Images);
                    return new Result<bool>(false);

                }
            }
            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<bool>> ResetPassword(ResetPasswordVM resetPassword)
        {
            try
            {
                #region Check If ModelState IsValid
                if (string.IsNullOrWhiteSpace(resetPassword.Password) || string.IsNullOrWhiteSpace(resetPassword.RePassword) || string.IsNullOrWhiteSpace(resetPassword.RequestCode))
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                #endregion

                #region Check If User Eixists
                resetPassword.RequestCode = Security.Decrypt(resetPassword.RequestCode);
                var user = await _uow.GetRepository<User>().Get(c => c.RequestCode == resetPassword.RequestCode).FirstOrDefaultAsync();
                if (user == null)
                {
                    return new Result<bool>(Messages.NotExistsData);
                }
                #endregion

                #region Change Password And User ActiveCode
                user.Password = Security.Encrypt(resetPassword.Password);
                user.RequestCode = Generator.UniqueNameGenerator();

                _uow.GetRepository<User>().Update(user);
                await _uow.SaveChangesAsync();

                #endregion
                return new Result<bool>(true);
            }

            catch (Exception ex)
            {
                return new Result<bool>(true);
            }
        }

        public async Task<Result<bool>> HasAccess(int roleId)
        {
            try
            {
                bool hasPermission = false;
                if (!_httpContextAccessor.HttpContext.User.Identity.IsAuthenticated)
                {
                    return new Result<bool>(false);
                }

                var user = _httpContextAccessor.HttpContext.User as ClaimsPrincipal;
                var roles = user.Claims.Where(c => c.Type == ClaimTypes.Role).ToList();

                foreach (var item in roles)
                {
                    var permissions = item.Value.Split("|").ToList();
                    var pId = Convert.ToInt32(permissions[0]);
                    bool isActive = Convert.ToBoolean(permissions[1]);

                    if (
                        (pId == roleId && isActive == true) ||
                        (pId == (int)AdminAuthorize.Admin && isActive == true) ||
                         pId == (int)AdminAuthorize.SuperAdmin)
                    {
                        hasPermission = true;
                        break;
                    };
                }

                return new Result<bool>(hasPermission);
            }

            catch (Exception ex)
            {
                return new Result<bool>(false);
            }
        }

        public async Task<Result<TokenVM>> GetToken(LoginFormVM login)
        {
            try
            {
                var param = new GetUserLoginParams() { Username = login.Username, Password = Security.Encrypt(login.Password) };

                var model = await _uow.ExecuteReader<AdminUserVM>(null, "GetUserLogin", param);

                if (model == null || model.Count() == 0)
                {
                    return new Result<TokenVM>(Messages.WrongUsernameOrPassword);
                }

                else
                {

                    var secretKey = AppsettingsGetter.Get("JWTCoreSettings:SecretKey");
                    var expirationMinutes = AppsettingsGetter.Get("JWTCoreSettings:TokenExpirationMinutes");

                    var key = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(secretKey));

                    var tokenHandler = new JwtSecurityTokenHandler();
                    var tokenDescriptor = new SecurityTokenDescriptor
                    {
                        Subject = new ClaimsIdentity(new Claim[]
                        {
                        new Claim("Id" , model.FirstOrDefault().UserId.ToString()),
                        new Claim("Name",    model.FirstOrDefault().Name),
                        new Claim("Family",  model.FirstOrDefault().Family),
                        new Claim("Email",   model.FirstOrDefault().Email),
                        new Claim("Username",model.FirstOrDefault().Username),
                        new Claim("Permissions", string.Join(',', model.Select(c=>c.PermissionId).ToList() ))
                        }),
                        Expires = DateTime.Now.AddMinutes(Convert.ToDouble(expirationMinutes)),
                        SigningCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256Signature),
                        Issuer = AppsettingsGetter.Get("JWTCoreSettings:Issuer"),
                        Audience = AppsettingsGetter.Get("JWTCoreSettings:Audience")
                    };

                    var token = tokenHandler.CreateToken(tokenDescriptor);
                    var accessToken = tokenHandler.WriteToken(token);

                    #region User Avatar

                    var user = model.FirstOrDefault();

                    #endregion

                    var tk = new TokenVM
                    {
                        Token = accessToken,
                        ExpireTime = tokenDescriptor.Expires,
                    };


                    return new Result<TokenVM>(tk);
                }

            }
            catch (Exception ex)
            {
                return new Result<TokenVM>(false);
            }
        }

        public async Task<Result<string>> GetUserAvatar()
        {
            try
            {
                var avatar = "";

                var user = await _uow.GetRepository<User>().GetWithInclude(c => c.Profile).FirstOrDefaultAsync(c => c.Id == ClaimHelper.GetUserId());
                if (user == null)
                {
                    return new Result<string>(false);
                }

                if (user.Profile.Avatar.ToLower().EndsWith("default.jpg"))
                {
                    avatar = await _fileManager.GetImageAsBase64String("Default.jpg", DefaultPath.DefultUserAvatar);
                }
                else
                {
                    avatar = await _fileManager.GetImageAsBase64String(user.Profile.Avatar, DefaultPath.Thumbnails);
                }

                return new Result<string>(data: avatar);
            }
            catch (Exception)
            {
                return new Result<string>(false);
            }
        }

        public async Task<Result<List<User>>> GetAll()
        {
            var data = await _uow.GetRepository<User>().Get(c => c.IsActive).OrderByDescending(c => c.CreatedOn).ToListAsync();

            return new Result<List<User>>(data);

        }

        public async Task<Result<PagingResultVM<UserListResultVM>>> Search(UserSearchVM search)
        {
            var query = _uow.GetRepository<User>()
                .GetWithInclude(c => c.Profile)
                .OrderByDescending(c => c.CreatedOn)
                .AsNoTracking();

            var recordsTotal = await query.CountAsync();


            if (string.IsNullOrWhiteSpace(search.Name) == false)
            {
                query = query.Where(c => c.Profile.Name.Contains(search.Name));
            }

            if (string.IsNullOrWhiteSpace(search.Family) == false)
            {
                query = query.Where(c => c.Profile.Family.Contains(search.Family));
            }

            if (string.IsNullOrWhiteSpace(search.Email) == false)
            {
                query = query.Where(c => c.Profile.Email.Contains(search.Email));
            }

            if (string.IsNullOrWhiteSpace(search.Username) == false)
            {
                query = query.Where(c => c.Username.Contains(search.Username));
            }

            var recordsFiltered = await query.CountAsync();

            var paged = query.ToPagedList(search.PageIndex, search.PageCount);
            var data = await paged.Select(c => new UserListResultVM
            {
                Email = c.Profile.Email,
                Family = c.Profile.Family,
                Id = c.Id,
                IsActive = c.IsActive,
                Name = c.Profile.Name,
                Username = c.Username,
                LastLogin = c.Profile.LastLogin
            }).ToListAsync();

            var result = new PagingResultVM<UserListResultVM> { Rows = data, Total = recordsTotal };

            return new Result<PagingResultVM<UserListResultVM>>(result);
        }
    }

}