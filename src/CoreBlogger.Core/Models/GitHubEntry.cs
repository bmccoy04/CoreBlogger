using System;
using Newtonsoft.Json;

namespace CoreBlogger.Core.Models
{
    public class GitHubEntry
    {
        public string Name { get; set; }
        public string Path { get; set; }
        public string Sha { get; set; }
        public string Url { get; set; }

        [JsonProperty("html_url")]
        public string HtmlUrl { get; set; }
        [JsonProperty("git_url")]
        public string GitUrl { get; set; }
        [JsonProperty("download_url")]
        public string DownloadUrl { get; set; }
        public string Type { get; set; }
    }
}