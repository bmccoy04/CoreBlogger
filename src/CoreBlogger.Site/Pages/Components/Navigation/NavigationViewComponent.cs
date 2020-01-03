using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CoreBlogger.Site.Components.Navigation
{
    public class NavigationViewComponent : ViewComponent
    {

        public NavigationViewComponent()
        {
        }

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}