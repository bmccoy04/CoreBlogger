using System.Collections.Generic;
using System.Threading.Tasks;
using CoreBlogger.Core.Models;
using MediatR;

namespace CoreBlogger.Core.Queries
{
    public class GetBlogEntriesQuery : IRequest<IList<GitHubBlogEntry>>
    {

    }
}