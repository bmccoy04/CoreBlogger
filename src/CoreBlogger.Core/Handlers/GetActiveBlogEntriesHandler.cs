
using CoreBlogger.Core.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using CoreBlogger.Core.Interfaces;
using CoreBlogger.Core.Models;

namespace CoreBlogger.Core.Handlers
{
    public class GetActiveBlogEntriesHandler : IRequestHandler<GetActiveBlogEntriesQuery, IList<GitHubBlogEntry>>
    {
        private readonly ILogger<GetActiveBlogEntriesHandler> _logger;
        private readonly ICachedGitHubEntryProvider _gitHubEntryProvider;

        public GetActiveBlogEntriesHandler(ILogger<GetActiveBlogEntriesHandler> logger, ICachedGitHubEntryProvider gitHubEntryProvider)
        {
            _logger = logger;
            _gitHubEntryProvider = gitHubEntryProvider;
        }

        public async Task<IList<GitHubBlogEntry>> Handle(GetActiveBlogEntriesQuery request, CancellationToken cancellationToken)
        {
            var entries = await _gitHubEntryProvider.GetEntries();
            return entries.Where(x => x.GitHubBlogEntryMetaData.Live).ToList();
        }

    }
}