using Microsoft.AspNetCore.Mvc;
using PortfolioWebsiteApp.Repositories.Interfaces;

namespace PortfolioWebsiteApp.Controllers
{
    public class BlogsController : Controller
    {
        public BlogsController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
