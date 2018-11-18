using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CoreBlogger.Core.Models;

namespace CoreBLogger.Core.Interfaces
{
    public interface IGitHubEntryClient
    {
        Task<IList<GitHubEntry>> GetEntries();
    }
}