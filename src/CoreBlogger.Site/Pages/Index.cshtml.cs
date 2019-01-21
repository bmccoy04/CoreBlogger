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
using CoreBlogger.Site.Models;

namespace CoreBlogger.Site.Pages
{
    public class IndexModel : PageModel
    {
        private ILogger<IndexModel> _logger;
        private IMediator _mediator;
        public IList<BlogPreviewVm> Blogs { get; set; }
        public string ErrorMessage { get; set; }

        public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
            Blogs = new List<BlogPreviewVm>();
        }

        public async Task OnGetAsync()
        {
            
            try 
            {
                var blogEntires = await _mediator.Send(new GetActiveBlogEntriesQuery());
                
                foreach (var blogEntry in blogEntires.OrderByDescending(x => x.GitHubBlogEntryMetaData.Date))
                {
                    this.Blogs.Add(new BlogPreviewVm(blogEntry.PreviewContent, blogEntry.GitHubBlogEntryMetaData.Date));
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
