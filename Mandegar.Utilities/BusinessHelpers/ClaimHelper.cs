using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;

namespace Mandegar.Utilities.BusinessHelpers
{
    public static class ClaimHelper
    {
        private static IHttpContextAccessor httpContextAccessor;
        public static void SetHttpContextAccessor(IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
        }

        public static int GetUserId()
        {
            var identity = (ClaimsIdentity)httpContextAccessor.HttpContext.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var userId = int.Parse(claims.FirstOrDefault(c => c.Type == "Id").Value.ToString());
            return userId;
        }

        public static List<int> GetPermissions()
        {
            var identity = (ClaimsIdentity)httpContextAccessor.HttpContext.User.Identity;
            IEnumerable<Claim> claims = identity.Claims;
            var permissions = claims.FirstOrDefault(c => c.Type == "Permissions").Value;
            List<int> perms = new List<int>();

            foreach (var s in permissions.Split(','))
            {
                int num;
                if (int.TryParse(s, out num))
                {
                    perms.Add(num);
                }
            }

            return perms;

        }
    }
}
