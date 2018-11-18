using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CoreBlogger.Core.Clients;
using CoreBlogger.Core.Models;

namespace CoreBlogger.Site.Pages
{
    public class IndexModel : PageModel
    {
        private ILogger<IndexModel> _logger;
        private GitHubEntryClient _gitHubEntryClient;

        private const string baseUrl = "https://api.github.com/repos/bmccoy04/CoreBlogger/contents/BlogEntries/";

        public IList<string> Blogs { get; set; }
        public string ErrorMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            _gitHubEntryClient = new GitHubEntryClient(baseUrl, new HttpClient());
            Blogs = new List<string>();
        }

        public async Task OnGetAsync()
        {
            
            try 
            {
                var items = await _gitHubEntryClient.GetEntries();
                var re = "";
                foreach (var item in items)
                {
                    _logger.LogInformation(item.Name);

                    this.Blogs.Add(await _gitHubEntryClient.GetEntryContent(item));
                }
            } 
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error");
                if(ex != null)
                    ErrorMessage = ex.Message;
            }
        }
    }    
}
