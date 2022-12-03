using Microsoft.AspNetCore.Http;
using Mandegar.Utilities.Interfaces;
using System;
using System.Threading.Tasks;

namespace Mandegar.Utilities.BusinessHelpers
{
    public class CookieManager : ICookieManager
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CookieManager(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        /// <summary>
        /// Get Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task<string> Get(string key)
        {
            return await Task.Run(() =>
            {
                return _httpContextAccessor.HttpContext.Request.Cookies[key];
            });
        }

        /// <summary>
        /// Remove Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public async Task Remove(string key)
        {
            await Task.Run(() =>
            {
                _httpContextAccessor.HttpContext.Response.Cookies.Delete(key);
            });
        }

        /// <summary>
        /// Set Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime">Per Hour</param>
        /// <returns></returns>
        public async Task Set(string key, string value, int? expireTime)
        {
            await Task.Run(() =>
             {
                 CookieOptions option = new CookieOptions();

                 if (expireTime.HasValue)
                     option.Expires = DateTime.Now.AddMinutes(expireTime.Value);
                 else
                     option.Expires = DateTime.Now.AddHours(24);

                 _httpContextAccessor.HttpContext.Response.Cookies.Append(key, value, option);
             });
        }
    }
}
