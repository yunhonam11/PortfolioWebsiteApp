using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Models.ViewModels;

namespace PortfolioWebsiteApp.Controllers
{
    public class UsersController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            IList<AppUser> adminMList = await _userManager.GetUsersInRoleAsync("Admin");
            IList<AppUser> userMList = await _userManager.GetUsersInRoleAsync("User");
            List<string> adminUsernameList = new List<string>();
            List<string> adminNameList  = new List<string>();
            List<string> userUsernameList = new List<string>();
            List<string> userNameList = new List<string>();

            for (int i = 0; i < adminMList.Count; i++)
            {
                var admin = adminMList.ElementAt(i);
                adminUsernameList.Add(admin.UserName);
                adminNameList.Add(admin.Name);
            }

            for (int i = 0; i < userMList.Count; i++)
            {
                var user = userMList.ElementAt(i);
                userUsernameList.Add(user.UserName);
                userNameList.Add(user.Name);
            }

            UsersViewModel usersVM = new UsersViewModel()
            {
                adminUsernames = adminUsernameList,
                adminNames = adminNameList,
                userUsernames = userUsernameList,
                userNames = userNameList
            };

            return View(usersVM);
        }
    }
}
