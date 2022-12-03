using Mandegar.Models.Entities.Log;
using Mandegar.Repository.Repositories.Interfaces;
using Mandegar.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Mandegar.Services.Impeliments
{
    public class LogExceptionService : ILogExceptionService
    {
        private readonly ILogExceptionRepository _logExceptionRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogExceptionService(ILogExceptionRepository logExceptionRepository, IHttpContextAccessor httpContextAccessor)
        {
            _logExceptionRepository = logExceptionRepository;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Log(Exception ex)
        {
            if (ex != null)
            {
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

                var request = await GetRequestBody(_httpContextAccessor.HttpContext);

                var exLog = new ExceptionLog
                {
                    Message = message,
                    Exception = exception,
                    Url = $"{_httpContextAccessor.HttpContext.Request.Host.Value}/{_httpContextAccessor.HttpContext.Request?.Path}",
                    Request = request,
                    Source = ex.Source,
                    StackTrace = ex.StackTrace
                };

                await _logExceptionRepository.Log(exLog);
            }
        }

        private async Task<string> GetRequestBody(HttpContext httpContext)
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
    }
}
