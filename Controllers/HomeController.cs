using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Models.ViewModels;
using PortfolioWebsiteApp.Repositories.Interfaces;
using System.Diagnostics;

namespace PortfolioWebsiteApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeRepository _homeRepository;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IPhotoService _photoService;
        public HomeController(IHomeRepository homeRepository, SignInManager<AppUser> signInManager, IPhotoService photoService)
        {
            _homeRepository = homeRepository;
            _signInManager = signInManager;
            _photoService = photoService;
        }

        public IActionResult Index()
        {
            // An empty home model always has to be initialized when this project is deployed for the first time.
            if (_homeRepository.Count() == 0)
            {
                _homeRepository.InitHome();
            }

            HomeViewModel homeVM = new HomeViewModel {
                Picture = _homeRepository.GetPictureUrl(),
                Title = _homeRepository.GetTitle(),
                Body = _homeRepository.GetBody()
            };

            return View(homeVM);
        }

        [HttpPost]
        [Route("/Home/EditTitle")]
        public IActionResult editTitle(HomeViewModel HomeVM)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _homeRepository.SaveTitle(HomeVM.Title);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("/Home/EditBody")]
        public IActionResult EditBody(HomeViewModel homeVM)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _homeRepository.SaveBody(homeVM.Body);
                
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        [Route("/Home/EditPicture")]
        public async Task<IActionResult> EditPicture(HomeViewModel homeVM)
        {

            var photoResult = await _photoService.AddPhotoAsync(homeVM.PictureFile, "null", 260, 320);
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _homeRepository.SavePictureUrl(photoResult.Url.ToString());

            return RedirectToAction("Index", "Home");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}