
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Mandegar.Models.HelperModels;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace Mandegar.Middlewares
{
    public class TrustedUrlsMiddleware
    {
        private readonly RequestDelegate _next;

        public TrustedUrlsMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext httpContext, IConfiguration configuration)
        {
            var projectAssemblyName = Assembly.GetEntryAssembly().GetName().Name;
            var list = new List<string>();
            var trustedUrls = configuration.GetSection($"TrustUrls:{projectAssemblyName}").Value?.Split(';');

            var remoteIpAddress = httpContext.Request.HttpContext.Connection.RemoteIpAddress.ToString();
            
            if (!trustedUrls.Any(c => c == remoteIpAddress))
            {
                httpContext.Response.StatusCode = StatusCodes.Status403Forbidden;
                var result = new Result<object>
                {
                    Data = StatusCodes.Status403Forbidden,
                    Message = StatusCodes.Status403Forbidden.ToString(),
                };
                await httpContext.Response.WriteAsJsonAsync(result);
            }

            await _next(httpContext);
        }

    }

    public static class UseTrustedUrlsExtensions
    {
        public static IApplicationBuilder UseTrustedUrls(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<TrustedUrlsMiddleware>();
        }
    }

}
