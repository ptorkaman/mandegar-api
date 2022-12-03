using Mandegar.Models.Entities.Log;
using Mandegar.Models.HelperModels;
using Mandegar.Services.Interfaces;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Middlewares
{
    // You may need to install the Microsoft.AspNetCore.Http.Abstractions package into your project
    public class ExceptionLoggerMiddleware
    {
        #region Initial
        private readonly RequestDelegate _next;

        private readonly ILoggerFactory _loggerFactory;

        private readonly IWebHostEnvironment _env;
        #endregion

        public ExceptionLoggerMiddleware(RequestDelegate next, ILoggerFactory loggerFactory, IWebHostEnvironment env)
        {
            _next = next;
            _loggerFactory = loggerFactory;
            _env = env;
        }

        public async Task Invoke(HttpContext httpContext, ILogExceptionService logExceptionService,
            IConfiguration configuration)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                #region Elastic

                var _logger = _loggerFactory.CreateLogger<ExceptionLoggerMiddleware>();

                var exception = JsonConvert.SerializeObject(ex.ToString());
                var message = ex?.Message + Environment.NewLine;

                if (ex.InnerException != null)
                {
                    message += ex.InnerException.Message + Environment.NewLine;
                }

                if (ex.InnerException?.InnerException != null)
                {
                    message += ex.InnerException?.InnerException?.Message + Environment.NewLine;

                }

                var request = await GetRequestBody(httpContext);

                var exLog = new ExceptionLog
                {
                    Message = message,
                    Exception = exception,
                    Url = $"{httpContext.Request.Host.Value}/{httpContext.Request?.Path}",
                    Request = request,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace
                };

                var msg = JsonConvert.SerializeObject(exLog);
                _logger.LogError(msg);

                #endregion

                #region DB

                logExceptionService.Log(ex);

                #endregion

                var result = new Result<Exception>();



                if (_env.IsDevelopment())
                {
                    result.Data = ex;
                }

                if (ex is UnauthorizedAccessException)
                {
                    httpContext.Response.StatusCode = 401;
                    result.Data = null;
                    result.Message = "Unauthorized";
                    result.Success = false;
                }

                var webUrls = configuration["UiProjectUrls"].Split(';').ToList();
                var host = $"{httpContext.Request.Scheme}://{httpContext.Request.Host.Value}";

                if (webUrls.Any(c => c == host))
                {
                    httpContext.Response.Redirect("/Error");
                }
                else
                {
                    await httpContext.Response.WriteAsJsonAsync(result);
                }

            }

        }

        #region HelperMethod

        public async Task<string> GetRequestBody(HttpContext httpContext)
        {
            return await Task.Run(() =>
            {
                if (httpContext.Request.HasFormContentType)
                {
                    var form = httpContext.Request?.Form ?? null;
                    var dic = new Dictionary<string, string>();
                    foreach (var item in form.Keys)
                    {
                        var val = form[item].ToString();
                        dic.Add(item, val);
                    }

                    return JsonConvert.SerializeObject(dic);
                }
                return "";
            });
        }
        #endregion
    }

    // Extension method used to add the middleware to the HTTP request pipeline.
    public static class ExceptionLoggerExtensions
    {
        public static IApplicationBuilder UseExceptionLogger(this IApplicationBuilder builder)
        {
            return builder.UseMiddleware<ExceptionLoggerMiddleware>();
        }
    }
}
