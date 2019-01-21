using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CoreBlogger.Core.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace CoreBlogger.Infrastructure.Clients
{
    public class GitHubClient : IGitHubClient
    {
        private HttpClient _httpClient;
        private string _url;

        public GitHubClient(IHttpClientFactory httpClientFactory, ILogger<GitHubClient> logger, IConfiguration configuration)
        {
            _httpClient = httpClientFactory.CreateClient();
            _url = configuration.GetValue<string>("BlogEntriesUri");
            _httpClient.DefaultRequestHeaders.Add("User-Agent", "request");
        }

        public async Task<T> GetEntriesAsync<T>()
        {
            var content = await _httpClient.GetStringAsync(_url);                
            return JsonConvert.DeserializeObject<T>(content);
        }

        public async Task<string> DownloadContent(string url)
        {
            var content = await _httpClient.GetStringAsync(url);
            return content;
        }
    }
}