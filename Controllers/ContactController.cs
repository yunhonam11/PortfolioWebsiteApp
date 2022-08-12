using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsiteApp.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
