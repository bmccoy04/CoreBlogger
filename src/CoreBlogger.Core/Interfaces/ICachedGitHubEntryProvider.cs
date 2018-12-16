using System.Collections.Generic;
using System.Threading.Tasks;
using CoreBlogger.Core.Models;

namespace CoreBlogger.Core.Interfaces
{
    public interface ICachedGitHubEntryProvider
    {
        Task<IList<GitHubBlogEntry>> GetEntries();

    }
}