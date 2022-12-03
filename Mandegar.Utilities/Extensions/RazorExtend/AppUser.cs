using Microsoft.AspNetCore.Http;
using Mandegar.Utilities.Enums;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Mandegar.Utilities.Extensions.RazorExtend
{
    public class AppUser : ClaimsPrincipal
    {
        private readonly HttpContext _httpContext;
        public AppUser(ClaimsPrincipal principal)
            : base(principal)
        {
            _httpContext = new HttpContextAccessor().HttpContext;
        }

        public string FirstName
        {
            get
            {

                return GetUserInfo("FirstName");
            }
        }

        public string LastName
        {
            get
            {
                return GetUserInfo("LastName");
            }
        }

        public string FullName
        {
            get
            {

                return GetUserInfo("FullName");
            }
        }

        public string PhoneNumber
        {
            get
            {
                return GetUserInfo("PhoneNumber");
            }
        }

        public string Email
        {
            get
            {
                return GetUserInfo("Email");
            }
        }

        public string Avatar
        {
            get
            {
                return GetUserInfo("Avatar");
            }
        }

        public string Id
        {
            get
            {
                return GetUserInfo("Id");
            }
        }

        public bool IsLogin
        {
            get
            {
                return GetUserInfo("Id") != null;
            }
        }

        public string UserName
        {
            get
            {
                return GetUserInfo("UserName");
            }
        }

        public RolesEnum UserType
        {
            get
            {
                return (GetUserRoles().Any(r => r == RolesEnum.Seller.ToString().ToLower())) ?
                    RolesEnum.Seller :
                    RolesEnum.Buyer;
            }
        }

        private string GetUserInfo(string claimName)
        {
            var stream = _httpContext.Session.GetString("User");
            if (string.IsNullOrWhiteSpace(stream))
            {
                return null;
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;

            var jti = tokenS?.Claims?.First(claim => claim.Type == claimName)?.Value;

            return jti;
        }


        private List<string> GetUserRoles()
        {
            var stream = _httpContext.Session.GetString("User");
            if (string.IsNullOrWhiteSpace(stream))
            {
                return null;
            }

            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(stream);
            var tokenS = jsonToken as JwtSecurityToken;

            var roles = tokenS?.Claims?.Where(claim => claim.Type == "Roles").Select(c=>c.Value.ToLower()).ToList();

            return roles;
        }


    }
}
