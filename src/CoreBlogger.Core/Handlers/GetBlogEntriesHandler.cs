using CoreBlogger.Core.Queries;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace CoreBlogger.Core.Handlers
{
    public class GetBlogEntriesHandler : IRequestHandler<GetBlogEntriesQuery, string>
    {
        private readonly ILogger<GetBlogEntriesHandler> _logger;
        public GetBlogEntriesHandler(ILogger<GetBlogEntriesHandler> logger)
        {
            _logger = logger;
        }

        public Task<string> Handle(GetBlogEntriesQuery request, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Called Handler");
            return Task.Run(() => "ME");
        }
    }
}