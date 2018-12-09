using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CoreBlogger.Site.Pages.Blogs
{
    public class IndexModel : PageModel
    {
        public string Message { get; set; }

        public void OnGet(string id)
        {
            this.Message = id;
        }
    }
}
