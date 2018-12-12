using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreBlogger.Core.Queries;
using CoreBlogger.Site.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace CoreBlogger.Site.Pages.Blogs
{
    public class IndexModel : PageModel
    {
        private ILogger<IndexModel> _logger;
        private IMediator _mediator;

        public string Message { get; set; }

        public BlogVm BlogVm {get;set;}

        public bool HasBlog { get { return this.BlogVm != null; } }

        public IndexModel(ILogger<IndexModel> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public async Task OnGetAsync(string id)
        {
            try 
            {
                if(!String.IsNullOrEmpty(id))
                    this.BlogVm = await GetBlogVm(id);

                this.Message = id + this.BlogVm;
            } 
            catch (Exception ex)
            {
                this.Message = ex.Message;
            }

            
        }

        private async Task<BlogVm> GetBlogVm(string id)
        {
            var entries = await _mediator.Send(new GetBlogEntriesQuery());
            var entry = entries.FirstOrDefault(x => x.GitHubBlogEntryMetaData.Date.ToString("yyyyMMdd") == id);
            var index = entries.IndexOf(entry);
            var previousId = String.Empty;
            var nextId = string.Empty;
            
            if(index > 0)
                previousId = entries[index - 1].GitHubBlogEntryMetaData.Date.ToString("yyyyMMdd");
            if(index < entries.Count - 1)
                nextId = entries[index + 1].GitHubBlogEntryMetaData.Date.ToString("yyyyMMdd");

            return new BlogVm(entry.Content, previousId, nextId);

        }
    }
}
