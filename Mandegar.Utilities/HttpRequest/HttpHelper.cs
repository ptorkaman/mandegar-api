using Flurl.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Mandegar.Utilities.Enums;
using Mandegar.Utilities.Interfaces;
using System;
using System.Threading.Tasks;
using Mandegar.Utilities.Extensions;

namespace Mandegar.Utilities.HttpRequest
{
    public class HttpHelper : IHttpHelper
    {
        private readonly IConfiguration configuration;
        private readonly string token;
        private readonly HttpContext _httpContext;

        public HttpHelper(IConfiguration configuration, string token = null, HttpContext httpContext = null)
        {
            this.configuration = configuration;
            this.token = token;
            _httpContext = httpContext;
        }

        public async Task<T> Get<T>(string api, object parms, ApiProjects apiProjects = ApiProjects.Admin)
        {
            var projectUrl = GetProjectUrl(apiProjects);
            var url = "";
            if (parms == null)
            {
                url = $"{projectUrl}/{api}";
            }
            else
            {
                var qs = parms.ObjectToQueryString();
                url = $"{projectUrl}/{api}?{qs}";
            }

            var lang = _httpContext.Request.Cookies["lang"];

            if (string.IsNullOrWhiteSpace(lang))
            {
                lang = _httpContext.Request.Headers["lang"];
            }

            var resp = (string.IsNullOrWhiteSpace(token)) ? await url.WithHeader("lang", lang).GetJsonAsync<T>() : await url.WithHeader("lang", lang).WithOAuthBearerToken(token).GetJsonAsync<T>();

            return (T)resp;
        }

        public async Task<T> Post<T>(string api, object parms, ApiProjects apiProjects = ApiProjects.Admin)
        {
            var projectUrl = GetProjectUrl(apiProjects);
            var url = $"{projectUrl}/{api}";

            var lang = _httpContext.Request.Cookies["lang"];

            if (string.IsNullOrWhiteSpace(lang))
            {
                lang = _httpContext.Request.Headers["lang"];
            }

            return string.IsNullOrWhiteSpace(token)
                ? await url.WithHeaders(new { Content_Type = "application/json", charset = "utf8", lang = lang }).PostJsonAsync(parms).ReceiveJson<T>()
                : await url.WithOAuthBearerToken(token).WithHeaders(new { Content_Type = "application/json", charset = "utf8", lang = lang }).PostJsonAsync(parms).ReceiveJson<T>();

        }

        private string GetProjectUrl(ApiProjects apiProjects)
        {
            return configuration[$"ApiUrls:{apiProjects}Api"];
        }
    }
}
