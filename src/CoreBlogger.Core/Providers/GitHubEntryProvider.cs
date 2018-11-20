using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoreBlogger.Core.Models;
using CoreBlogger.Core.Interfaces;
using Newtonsoft.Json;

namespace CoreBlogger.Core.Providers
{
    public class GitHubEntryProvider : IGitHubEntryProvider
    {
        private IGitHubClient _gitHubClient;

        public GitHubEntryProvider(IGitHubClient gitHubClient)
        {
            //_httpClient = httpClientFactory.CreateClient();
            _gitHubClient = gitHubClient;
        }

        public async Task<IList<GitHubEntry>> GetEntries()
        {
                //var response = httpClient.GetStringAsync("https://api.github.com/repos/bmccoy04/CoreBlogger/contents/BlogEntries/");
                //var response = httpClient.GetStringAsync("https://api.github.com/repos/bmccoy04/CoreBlogger/contents/BlogEntries/Test!.md");
                //var response = httpClient.GetStringAsync("https://raw.githubusercontent.com/bmccoy04/CoreBlogger/master/BlogEntries/Test!.md");

               
                
                //var content = await _httpClient.GetStringAsync(_url);                
                //var items = JsonConvert.DeserializeObject<List<GitHubEntry>>(content);
                var items = await _gitHubClient.GetEntriesAsync<List<GitHubEntry>>();
                return items;
        }

        public async Task<string> DownloadContent(GitHubEntry entry)
        {
            return await _gitHubClient.DownloadContent(entry.DownloadUrl);
        }
    }       
}
