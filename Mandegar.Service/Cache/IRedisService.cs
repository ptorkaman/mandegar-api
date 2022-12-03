using Mandegar.Utilities.Enums;
using System.Threading.Tasks;

namespace Mandegar.Services.Cache
{
    public interface IRedisService
    {
        Task<T> GetAsync<T>(string key, RedisDb db = RedisDb.LocalStringResource);
        Task<T> SetAsync<T>(string key, T value, RedisDb db = RedisDb.LocalStringResource);
        Task<bool> DeleteAsync(string key, RedisDb db = RedisDb.LocalStringResource);
    }
}
