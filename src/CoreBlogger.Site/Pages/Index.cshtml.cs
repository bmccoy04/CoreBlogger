using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using CoreBlogger.Core.Providers;
using CoreBlogger.Core.Models;
using MediatR;
using CoreBlogger.Core.Queries;
using CoreBlogger.Core.Interfaces;

namespace CoreBlogger.Site.Pages
{
    public class IndexModel : PageModel
    {
        private ILogger<IndexModel> _logger;
        private IMediator _mediator;
        private IGitHubEntryProvider _gitHubEntryProvider;

        private const string baseUrl = "https://api.github.com/repos/bmccoy04/CoreBlogger/contents/BlogEntries/";

        public IList<string> Blogs { get; set; }
        public string ErrorMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IMediator mediator, IGitHubEntryProvider entryProvider)
        {
            _logger = logger;
            _gitHubEntryProvider = entryProvider;
            _mediator = mediator;
            Blogs = new List<string>();
        }

        public async Task OnGetAsync()
        {
            
            try 
            {
                var blogEntires = await _mediator.Send(new GetBlogEntriesQuery());
                var items = await _gitHubEntryProvider.GetEntries();
                foreach (var item in items)
                {
                    _logger.LogInformation(item.Name);

                    this.Blogs.Add(await _gitHubEntryProvider.DownloadContent(item));
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
