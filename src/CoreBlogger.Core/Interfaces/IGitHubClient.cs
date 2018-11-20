using System.Threading.Tasks;

namespace CoreBlogger.Core.Interfaces
{
    public interface IGitHubClient
    {
        Task<T> GetEntriesAsync<T>();
        Task<string> DownloadContent(string url);
    }
}