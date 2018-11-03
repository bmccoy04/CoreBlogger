using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CoreBlogger.Site.Pages
{
    public class IndexModel : PageModel
    {
        private ILogger<IndexModel> _logger;

        public string Blogs { get; set; }
        public string ErrorMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public async Task OnGetAsync()
        {
            
            try 
            {
                var httpClient = new HttpClient();
                var response = httpClient.GetStringAsync("https://api.github.com/repos/bmccoy04/CoreBlogger/contents/BlogEntries/");
                
                Blogs = await response;
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
