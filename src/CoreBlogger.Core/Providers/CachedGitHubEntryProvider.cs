using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoreBlogger.Core.Models;
using CoreBlogger.Core.Interfaces;
using Newtonsoft.Json;
using Microsoft.Extensions.Logging;
using CoreBlogger.Core.Constants;

namespace CoreBlogger.Core.Providers
{
    public class CachedGitHubEntryProvider : ICachedGitHubEntryProvider
    {
        private readonly ILogger<CachedGitHubEntryProvider> _logger;
        private readonly IGitHubEntryProvider _gitHubEntryProvider;
        private readonly IApplicationCacheProvider _applicationCacheProvider;

        public CachedGitHubEntryProvider(
            ILogger<CachedGitHubEntryProvider> logger, 
            IGitHubEntryProvider gitHubEntryProvider, 
            IApplicationCacheProvider applicationCacheProvider)
        {
            _logger = logger;
            _gitHubEntryProvider = gitHubEntryProvider;
            _applicationCacheProvider = applicationCacheProvider;
        }

        public async Task<IList<GitHubBlogEntry>> GetEntries()
        {
            
            var entries = _applicationCacheProvider.Get(CacheKeys.BlogEntries) as IList<GitHubBlogEntry>;

            if(entries == null) {
                entries = await LoadNonCached();
                _applicationCacheProvider.Insert(CacheKeys.BlogEntries, entries, DateTime.Now.AddHours(1));
            }
                

            return entries;
        }

        private async Task<IList<GitHubBlogEntry>> LoadNonCached()
        {
            _logger.LogDebug("Non cached version loaded");
            var entries = await _gitHubEntryProvider.GetEntries();

            foreach (var entry in entries)
            {
                entry.SetContent(await _gitHubEntryProvider.DownloadContent(entry));
            }

            return entries;
        }
    }       
}
