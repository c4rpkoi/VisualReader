using Newtonsoft.Json;
using StackExchange.Redis;

namespace VisualReader
{
    public class CacheService : ICacheService
    {
        private readonly Lazy<ConnectionMultiplexer> _lazyConnection;
        private readonly CacheOptions _options;

        public CacheService(CacheOptions options)
        {
            _options = options;
            var configOptions = new ConfigurationOptions
            {
                EndPoints = { _options.Host },
                Password = _options.Password,
                Ssl = _options.Ssl,
                AbortOnConnectFail = _options.AbortOnConnectFail,
                DefaultDatabase = _options.Database
            };

            _lazyConnection = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configOptions));
        }

        private ConnectionMultiplexer Connection => _lazyConnection.Value;

        public async Task<T> GetAsync<T>(string key, int? database = null)
        {
            var databaseNumber = database ?? _options.Database;
            var redisDatabase = Connection.GetDatabase(databaseNumber);
            var value = await redisDatabase.StringGetAsync(key);
            if (!value.HasValue)
            {
                return default;
            }
            return JsonConvert.DeserializeObject<T>(value);
        }

        public async Task<string> GetStringAsync(string key, int? database = null)
        {
            var databaseNumber = database ?? _options.Database;
            var redisDatabase = Connection.GetDatabase(databaseNumber);
            return await redisDatabase.StringGetAsync(key);
        }

        public async Task SetAsync<T>(string key, T value, TimeSpan duration, int? database = null)
        {
            var databaseNumber = database ?? _options.Database;
            var redisDatabase = Connection.GetDatabase(databaseNumber);
            await redisDatabase.StringSetAsync(key, JsonConvert.SerializeObject(value), duration);
        }

        public async Task DeleteAsync(string key, int? database = null)
        {
            var databaseNumber = database ?? _options.Database;
            var redisDatabase = Connection.GetDatabase(databaseNumber);
            await redisDatabase.KeyDeleteAsync(key);
        }
    }
}