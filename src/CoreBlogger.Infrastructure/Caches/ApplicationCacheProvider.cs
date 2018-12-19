using System;
using CoreBlogger.Core.Interfaces;
using Microsoft.Extensions.Caching.Memory;

namespace CoreBlogger.Infrastructure.Clients
{
    public class ApplicationCacheProvider : IApplicationCacheProvider
    {
        private readonly IMemoryCache _memoryCache;

        public ApplicationCacheProvider(IMemoryCache memoryCache)
        {
            _memoryCache = memoryCache;
        }

        public object Get(string key)
        {
            return _memoryCache.Get(key);
        }

        public void Insert(string key, object items, DateTime experation)
        {
            _memoryCache.Set(key, items, experation);
        }
    }
}