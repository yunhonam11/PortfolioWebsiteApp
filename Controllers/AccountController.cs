using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Models.ViewModels;
using System.Net;
using System.Net.Mail;

namespace PortfolioWebsiteApp.Controllers
{
    public class AccountController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly static string smtpAddress = "smtp.office365.com";
        private readonly static int portNumber = 587;
        private readonly static bool enableSSL = true;
        private readonly static string emailFromAddress = "namyun_toronto@outlook.com"; //Sender Email Address  
        private readonly static string password = "123%^00nn"; //Sender Password  

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            //var user = await _userManager.FindByNameAsync("namyun");
            //var result = _userManager.DeleteAsync(user);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerVM)
        {
            var emailCheck = await _userManager.FindByEmailAsync(registerVM.EmailAddress);
            var nameCheck = await _userManager.FindByNameAsync(registerVM.UserName);

            if (emailCheck != null)
            {
                if (emailCheck.IsEmailConfirmed == true)
                {
                    ModelState.AddModelError("EmailExists", "That Email is already registered with us.");
                    return View();
                }
                else
                {
                    ValidationViewModel validationVM = new ValidationViewModel
                    {
                        EmailAddress = emailCheck.Email,
                    };

                    return RedirectToAction("ValidationFirst", "Account", validationVM);
                }
            }

            if (nameCheck != null)
                ModelState.AddModelError("NameExists", "That Username already exists.");
            
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser
                {
                    Name = registerVM.FirstName + " " + registerVM.LastName,
                    UserName = registerVM.UserName,
                    Email = registerVM.EmailAddress,
                    IsEmailConfirmed = false,
                };

                var result = await _userManager.CreateAsync(appUser, registerVM.Password);
                if (result.Succeeded)
                {
                    ValidationViewModel validationVM = new ValidationViewModel
                    {
                        EmailAddress = appUser.Email,
                    };

                    return RedirectToAction("ValidationFirst", "Account", validationVM);
                }
            }

            return View();
        }

        [HttpGet]
        public IActionResult ValidationFirst(ValidationViewModel validationVM)
        {
            return View(validationVM);
        }

        [HttpPost]
        public IActionResult ValidationFirst(ValidationViewModel validationVM, string? postUniqueParam)
        {
            string passcode = "";
            var random = new Random();

            for (int i = 0; i < 6; i++)
            {
                int num = random.Next(0, 9);
                while (passcode.Contains(num.ToString()))
                {
                    num = random.Next(0, 9);
                }
                passcode += num.ToString();
            }

            string emailToAddress = validationVM.EmailAddress;
            string subject = "YunFolio sign up confirmation.";
            string body = "Hello!<br><br>Welcome aboard! Thank you for signing up to my website. " +
                "Please confirm your email address by entering the provided 6-digit passcode<br>" +
                "on the passcode page.<br>" + "<h3>" + passcode + "</h3>" +
                "<br> Best,<br>Yunho Nam";

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(emailFromAddress);
            mail.To.Add(emailToAddress);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(smtpAddress, portNumber);
            smtp.Credentials = new NetworkCredential(emailFromAddress, password);
            smtp.EnableSsl = enableSSL;
            smtp.Send(mail);

            validationVM.Passcode = passcode;

            return RedirectToAction("ValidationSecond", "Account", validationVM);
        }

        [HttpGet]
        public IActionResult ValidationSecond(ValidationViewModel validationVM)
        {
            validationVM.Attempts = 3;
            return View(validationVM);
        }

        [HttpPost]
        public async Task<IActionResult> ValidationSecond(ValidationViewModel validationVM, string? postUniqueParam)
        {
            string? email = validationVM.EmailAddress;
            string? passcode = validationVM.Passcode;
            if (passcode[0].ToString() == validationVM.Pass1 & passcode[1].ToString() == validationVM.Pass2 &
                passcode[2].ToString() == validationVM.Pass3 & passcode[3].ToString() == validationVM.Pass4 &
                passcode[4].ToString() == validationVM.Pass5 & passcode[5].ToString() == validationVM.Pass6)
            {
                AppUser appUser = await _userManager.FindByEmailAsync(email);
                appUser.IsEmailConfirmed = true;
                await _signInManager.SignInAsync(appUser, isPersistent: false);
                await _userManager.UpdateAsync(appUser);
                TempData["Home"] = "You have successfully confirmed your account.";
                return RedirectToAction("Index", "Home");
            } else if (validationVM.Attempts != 0)
            {
                validationVM.Attempts -= 1;
                ModelState.AddModelError("Passcode", "Wrong passcode. You have " + validationVM.Attempts.ToString() + " attempts remaining.");
                return View(validationVM);
            } else if (validationVM.Attempts == 0)
            {
                return RedirectToAction("ValidationFirst", "Account", validationVM.EmailAddress);
            } else
            {
                return RedirectToAction("SignUp", "Account");
            }
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginVM)
        {
            AppUser appUser = await _userManager.FindByEmailAsync(loginVM.EmailAddress);

            if (appUser == null)
            {
                ModelState.AddModelError("NoEmail", "The Email you've provided is not registered with us.");
            } else
            {
                if (appUser.IsEmailConfirmed == false)
                {
                    ModelState.AddModelError("Unconfirmed", "The Email you've provided has not been confirmed yet. " +
                        "Return to Sign Up page and you can re-register to receive another confirmation email.");
                }
                else
                {
                    var result = await _signInManager.CheckPasswordSignInAsync(appUser, loginVM.Password, false);
                    if (result.Succeeded)
                    {
                        if (loginVM.RememberMe == "true")
                        {
                            await _signInManager.SignInAsync(appUser, true);
                        }
                        else
                        {
                            await _signInManager.SignInAsync(appUser, false);
                        }
                        TempData["Home"] = "You have successfully logged into your account";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ModelState.AddModelError("Password", "You have provided the wrong password. Try again.");
                    }
                }
            }

            return View();
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            TempData["Home"] = "You have successfully logged out of your account";
            return RedirectToAction("Index", "Home");
        }
    }
}
