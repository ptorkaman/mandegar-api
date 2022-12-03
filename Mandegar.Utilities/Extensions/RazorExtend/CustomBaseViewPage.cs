using Microsoft.AspNetCore.Mvc.Razor;
using System.Security.Claims;

namespace Mandegar.Utilities.Extensions.RazorExtend
{
    public abstract class AppViewPage<TModel> : RazorPage<TModel>
    {
        protected AppUser CurrentUser
        {
            get
            {
                return new AppUser(this.User as ClaimsPrincipal);
            }
        }
    }

    public abstract class AppViewPage : AppViewPage<dynamic>
    {
    }
}
