using System;
using System.Diagnostics;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.StackExchangeRedis;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using Xunit;

namespace PreferenceManager.IntegrationTests;

public class CacheIntegrationTest
{
    public static void CacheCreation()
    {
        try
        {
            string server = "localhost";
            string port = "6379";
            string cnstring = $"{server}:{port}";

            var redisOptions = new RedisCacheOptions
            {
                ConfigurationOptions = new ConfigurationOptions()
            };
            redisOptions.ConfigurationOptions.EndPoints.Add(cnstring);
            var opts = Options.Create<RedisCacheOptions>(redisOptions);

            IDistributedCache cache = new Microsoft.Extensions.Caching.StackExchangeRedis.RedisCache(opts);
            string expectedStringData = "Hello world";
            cache.Set("key003", System.Text.Encoding.UTF8.GetBytes(expectedStringData));
            var dataFromCache = cache.Get("key003");
            var actualCachedStringData = System.Text.Encoding.UTF8.GetString(dataFromCache);
            Assert.Equal(expectedStringData, actualCachedStringData);
        }
        catch (Exception ex)
        {
            Trace.WriteLine(ex.ToString());
            throw;
        }
    }
}