using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoreBlogger.Core.Models;
using CoreBLogger.Core.Interfaces;
using Newtonsoft.Json;

namespace CoreBlogger.Core.Clients
{
    public class GitHubEntryClient : IGitHubEntryClient
    {
        private string _url;
        private HttpClient _httpClient;

        public GitHubEntryClient(string url, HttpClient httpClientFactory)
        {
            _url = url;
            //_httpClient = httpClientFactory.CreateClient();
            _httpClient = httpClientFactory; // Change this to use HTTPClientFactory when you refactor
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "request");
        }

        public async Task<IList<GitHubEntry>> GetEntries()
        {
                //var response = httpClient.GetStringAsync("https://api.github.com/repos/bmccoy04/CoreBlogger/contents/BlogEntries/");
                //var response = httpClient.GetStringAsync("https://api.github.com/repos/bmccoy04/CoreBlogger/contents/BlogEntries/Test!.md");
                //var response = httpClient.GetStringAsync("https://raw.githubusercontent.com/bmccoy04/CoreBlogger/master/BlogEntries/Test!.md");

               
                
                var content = await _httpClient.GetStringAsync(_url);                
                var items = JsonConvert.DeserializeObject<List<GitHubEntry>>(content);
                
                return items;
        }

        public async Task<string> GetEntryContent(GitHubEntry entry)
        {
            return await _httpClient.GetStringAsync(entry.DownloadUrl);
        }
    }       
}
