using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Mandegar.Utilities.Enums;
using System.Linq;
using System.Security.Claims;

namespace Mandegar.Utilities.ActionFilters
{
    public class AdminAuthorizeAttribute : AuthorizeAttribute, IAuthorizationFilter
    {
        private int _permissionId = 0;
        private bool _justSuperAdmin = false;

        public AdminAuthorizeAttribute(int permissionId, bool justSuperAdmin = false)
        {
            _permissionId = permissionId;
            _justSuperAdmin = justSuperAdmin;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = context.HttpContext.User as ClaimsPrincipal;
                var roles = user.Claims.Where(c => c.Type == "Permissions").ToList();

                bool hasPermission = false;

                foreach (var item in roles)
                {

                    var permissions = item.Value.Split(",").ToList();
                    foreach (var per in permissions)
                    {
                        var pId = int.Parse(per);
                        if (
                            (pId == _permissionId) ||
                            (pId == (int)AdminAuthorize.Admin && _justSuperAdmin == false) ||
                            pId == (int)AdminAuthorize.SuperAdmin)
                        {
                            hasPermission = true;
                            break;
                        }
                    }

                }

                if (!hasPermission)
                {
                    context.HttpContext.Response.StatusCode = 401;
                }
            }
            else
            {
                context.HttpContext.Response.StatusCode = 401;
            }
        }

    }
}
