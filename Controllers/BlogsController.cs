using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsiteApp.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
