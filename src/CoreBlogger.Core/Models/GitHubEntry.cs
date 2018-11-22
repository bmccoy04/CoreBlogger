using System;
using Newtonsoft.Json;

namespace CoreBlogger.Core.Models
{
    public class GitHubEntry
    {

        public GitHubEntry(string name, string path, string sha, string downloadUrl)
        {
            Name = name;
            Path = path;
            Sha = sha;
            DownloadUrl = downloadUrl;
        }
        public string Name { get; private set; }
        public string Path { get; private set; }
        public string Sha { get; private set; }
        public string Url { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        [JsonProperty("git_url")]
        public string GitUrl { get; set; }
        [JsonProperty("download_url")]
        public string DownloadUrl { get; private set; }
        public string Type { get; set; }
    }
}