using Microsoft.AspNetCore.Mvc;

namespace PortfolioWebsiteApp.Controllers
{
    public class ResumeController : Controller
    {
        public ResumeController()
        {

        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
