using System;
using Newtonsoft.Json;

namespace CoreBlogger.Core.Models
{
    public class GitHubBlogEntry
    {
        public GitHubBlogEntry(string name, string path, string sha, string downloadUrl)
        {
            Name = name;
            Path = path;
            Sha = sha;
            DownloadUrl = downloadUrl;
        }

        public void SetContent(string content)
        {
            Content = content;
        }

        public string PreviewContent
        {
            get 
            {
                var stuff = Content.Split(new string[] {"<!--- End Preview --->"}, StringSplitOptions.None);
                if(stuff.Length > 1)
                    return stuff[0];

                return Content;
            }
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
        public string Content { get; internal set; }

        private GitHubBlogEntryMetaData _gitHubBlogEntryMetaData;
        public GitHubBlogEntryMetaData GitHubBlogEntryMetaData {
            get {
                if(_gitHubBlogEntryMetaData == null)
                    _gitHubBlogEntryMetaData = new GitHubBlogEntryMetaData(this.Content);
                    
                return _gitHubBlogEntryMetaData;
            }
        }
    }
}