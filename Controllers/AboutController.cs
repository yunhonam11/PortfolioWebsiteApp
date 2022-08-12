using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Models.ViewModels;
using PortfolioWebsiteApp.Repositories.Interfaces;

namespace PortfolioWebsiteApp.Controllers
{
    public class AboutController : Controller
    {
        private readonly IAboutRepository _aboutRepository;
        private readonly IPhotoService _photoService;
        private readonly SignInManager<AppUser> _signInManager;

        public AboutController(SignInManager<AppUser> signInManager, IAboutRepository aboutRepository, IPhotoService photoService)
        {
            _signInManager = signInManager;
            _aboutRepository = aboutRepository;
            _photoService = photoService;
        }

        public IActionResult Index()
        {
            //_aboutRepository.RemoveAll();
            //return View();
            if (_aboutRepository.Count() == 0)
            {
                _aboutRepository.InitAbout();
                _aboutRepository.Save();
            }

            AboutViewModel aboutVM = new AboutViewModel
            {
                Title = _aboutRepository.GetTitle(),
                Body = _aboutRepository.GetBody(),
                Logos = _aboutRepository.GetPictureUrls()
            };

            return View(aboutVM);
        }

        [HttpPost]
        [Route("/About/EditTitle")]
        public IActionResult EditTitle(AboutViewModel aboutVM)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _aboutRepository.SaveTitle(aboutVM.Title);

            return RedirectToAction("Index", "About");
        }

        [HttpPost]
        [Route("/About/EditBody")]
        public IActionResult EditBody(AboutViewModel aboutVM)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _aboutRepository.SaveBody(aboutVM.Body);
                
            return RedirectToAction("Index", "About");
        }

        [HttpPost]
        [Route("/About/AddLogo")]
        public async Task<IActionResult> AddLogo(AboutViewModel aboutVM)
        {
            var photoResult = await _photoService.AddPhotoAsync(aboutVM.LogoFile, "not null", 120, 160);
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _aboutRepository.SavePictureUrl(photoResult.Url.ToString());

            return RedirectToAction("Index", "About");
        }

        [HttpPost]
        [Route("/About/WipeLogos")]
        public IActionResult WipeLogos()
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
                _aboutRepository.RemoveAllLogos();
            return RedirectToAction("Index", "About");
        }
    }
}
