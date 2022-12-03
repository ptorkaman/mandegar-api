using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using Mandegar.Utilities.Extensions;

namespace Mandegar.Utilities.ActionFilters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false, Inherited = true)]
    public class ValidateCaptcha : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var controllerBase = context.Controller as ControllerBase;

            if (context == null)
            {
                throw new ArgumentNullException(nameof(context));
            }

            var httpContext = context.HttpContext;
            if (httpContext == null)
            {
                throw new InvalidOperationException("httpContext is null.");
            }

            if (context.HttpContext.Session.Get<string>("Captcha") == null)
            {
                controllerBase.ModelState.AddModelError("Captcha", "Captcha Is Not Valid");
            }

            base.OnActionExecuting(context);
        }
    }
}
