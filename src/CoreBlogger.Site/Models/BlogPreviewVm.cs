using System;

namespace CoreBlogger.Site.Models
{
    public class BlogPreviewVm
    {
        public BlogPreviewVm(string preview, DateTime date)
        {
            this.Preview = preview;
            this.DateString = date.ToString("yyyyMMdd");
        }
        public string Preview { get; private set; }
        
        public string DateString { get; private set; }
    }
}