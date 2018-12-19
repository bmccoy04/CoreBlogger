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
    public class GetBlogEntriesHandler : IRequestHandler<GetBlogEntriesQuery, IList<GitHubBlogEntry>>
    {
        private readonly ILogger<GetBlogEntriesHandler> _logger;
        private readonly ICachedGitHubEntryProvider _gitHubEntryProvider;

        public GetBlogEntriesHandler(ILogger<GetBlogEntriesHandler> logger, ICachedGitHubEntryProvider gitHubEntryProvider)
        {
            _logger = logger;
            _gitHubEntryProvider = gitHubEntryProvider;
        }

        public async Task<IList<GitHubBlogEntry>> Handle(GetBlogEntriesQuery request, CancellationToken cancellationToken)
        {
            var entries = _gitHubEntryProvider.GetEntries();

            return await entries;
        }

    }
}