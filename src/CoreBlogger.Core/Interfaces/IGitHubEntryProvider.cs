using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreBlogger.Core.Models;

namespace CoreBlogger.Core.Interfaces
{
    public interface IGitHubEntryProvider
    {
        Task<IList<GitHubEntry>> GetEntries();

        Task<string> DownloadContent(GitHubEntry entry);
    }
}