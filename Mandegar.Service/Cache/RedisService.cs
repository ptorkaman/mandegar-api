using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Mandegar.Utilities.Enums;
using StackExchange.Redis;
using System;
using System.Threading.Tasks;

namespace Mandegar.Services.Cache
{
    public class RedisService : IRedisService
    {
        private readonly IConfiguration _configuration;

        public RedisService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<T> GetAsync<T>(string key, RedisDb db = RedisDb.LocalStringResource)
        {

            var database = await ConnectDbAsync(db);

            var value = await database.StringGetAsync(key);

            if (value.HasValue)
            {
                return JsonConvert.DeserializeObject<T>(value);
            }

            return default;
        }

        public async Task<T> SetAsync<T>(string key, T value, RedisDb db = RedisDb.LocalStringResource)
        {
            var database = await ConnectDbAsync(db);
            var expire = int.Parse(_configuration[$"Redis:Expire:db{(int)db}"]);
            await database.StringSetAsync(key, JsonConvert.SerializeObject(value), TimeSpan.FromHours(expire));

            return value;
        }

        public async Task<bool> DeleteAsync(string key, RedisDb db = RedisDb.LocalStringResource)
        {
            var database = await ConnectDbAsync(db);
            return await database.KeyDeleteAsync(key);
        }

        private async Task<IDatabase> ConnectDbAsync(RedisDb db)
        {
            var serverName = _configuration["Redis:Server"];
            var port = _configuration["Redis:Port"];
            var password = _configuration["Redis:Password"];

            var configuration = $"{serverName}:{port},defaultDatabase=0,password={password},connectTimeout=20000,syncTimeout=2000,connectRetry=3,abortConnect=false";

            var redis = await ConnectionMultiplexer.ConnectAsync(configuration);
            var data = redis.GetDatabase((int)db);
            return data;
        }
    }
}
