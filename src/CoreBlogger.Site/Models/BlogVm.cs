using System;

namespace CoreBlogger.Site.Models
{
    public class BlogVm
    {
        public  BlogVm(string content, string previousBlogId, string nextBlogId)
        {
            Content = content;
            PreviousBlogId = previousBlogId;
            NextBlogId = nextBlogId;
        }
        public string Content { get; private set; } 
        public string PreviousBlogId { get; private set; }
        public string NextBlogId { get; private set; }
    }
}