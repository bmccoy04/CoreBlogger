using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CoreBlogger.Site.Pages
{
    public class IndexModel : PageModel
    {
        private ILogger<IndexModel> _logger;
        private GitHubEntryProvider _gitHubEntryProvider;

        private const string baseUrl = "https://api.github.com/repos/bmccoy04/CoreBlogger/contents/BlogEntries/";

        public string Blogs { get; set; }
        public string ErrorMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _gitHubEntryProvider = new GitHubEntryProvider(baseUrl, new HttpClient());
        }

        public async Task OnGetAsync()
        {
            
            try 
            {
                var items = await _gitHubEntryProvider.GetEntries();
                var re = "";
                foreach (var item in items)
                {
                    _logger.LogInformation(item.Name);
                    re = re + " <br /> " + item.DownloadUrl;
                }

                Blogs = re;
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                if(ex != null)
                    ErrorMessage = ex.Message;
            }
        }
    }

    public class GitHubEntryProvider : IGitHubEntryProvider
    {
        private string _url;
        private HttpClient _httpClient;

        public GitHubEntryProvider(string url, HttpClient httpClientFactory)
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
    }

    public interface IGitHubEntryProvider
    {
        Task<IList<GitHubEntry>> GetEntries();
    }

    public class GitHubEntry
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Sha { get; set; }
        public string Url { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        [JsonProperty("git_url")]
        public string GitUrl { get; set; }
        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }
        public string Type { get; set; }
    }



}
