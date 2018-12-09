using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreBlogger.Core.Models;

namespace CoreBlogger.Core.Interfaces
{
    public interface IGitHubEntryProvider
    {
        Task<IList<GitHubBlogEntry>> GetEntries();

        Task<string> DownloadContent(GitHubBlogEntry entry);
    }
}