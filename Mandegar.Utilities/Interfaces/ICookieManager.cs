using System.Threading.Tasks;

namespace Mandegar.Utilities.Interfaces
{
    public interface ICookieManager
    {
        /// <summary>
        /// Get Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task<string> Get(string key);

        /// <summary>
        /// Set Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <param name="value"></param>
        /// <param name="expireTime">Hour</param>
        /// <returns></returns>
        Task Set(string key, string value, int? expireTime);

        /// <summary>
        /// Remove Cookie
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        Task Remove(string key);
    }
}
