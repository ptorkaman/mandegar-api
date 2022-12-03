using System;
using System.Threading.Tasks;

namespace Mandegar.Services.Cache
{
    public interface IMemoryCacheService
    {
        T Get<T>(object key);
        Task<T> GetAsync<T>(object key);
        T GetOrSet<T>(object key, Func<T> build = default, TimeSpan? duration = default, bool purge = false);
        Task<T> GetOrSetAsync<T>(object key, Task<T> build = default, TimeSpan? duration = default, bool purge = false);
        void Remove(object key);
    }
}
