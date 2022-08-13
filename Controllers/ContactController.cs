using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Models.ViewModels;
using PortfolioWebsiteApp.Repositories.Interfaces;
using System.Net;
using System.Net.Mail;

namespace PortfolioWebsiteApp.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;
        private readonly SignInManager<AppUser> _signInManager;

        private readonly static string smtpAddress = "smtp.office365.com";
        private readonly static int portNumber = 587;
        private readonly static bool enableSSL = true;
        private readonly static string emailAddress = "namyun_toronto@outlook.com"; //Sender Email Address  
        private readonly static string password = "123%^00nn"; //Sender Password  

        public ContactController(IContactRepository contactRepository, SignInManager<AppUser> signInManager)
        {
            _contactRepository = contactRepository;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            if (_contactRepository.Count() == 0)
                _contactRepository.InitContact();

            ContactViewModel contactVM = new ContactViewModel
            {
                City = _contactRepository.GetCity(),
                Region = _contactRepository.GetRegion(),
                Country = _contactRepository.GetCountry(),
                EmailAddress = _contactRepository.GetEmail()
            };

            return View(contactVM);
        }

        [HttpPost]
        [Route("/Contact/EditInfo")]
        public IActionResult EditInfo(ContactViewModel contactVM)
        {
            if (_signInManager.IsSignedIn(User) && User.IsInRole("Admin"))
            {
                _contactRepository.SaveCity(contactVM.City);
                _contactRepository.SaveRegion(contactVM.Region);
                _contactRepository.SaveCountry(contactVM.Country);
                _contactRepository.SaveEmail(contactVM.EmailAddress);
            }

            return RedirectToAction("Index", "Contact");
        }

        [HttpPost]
        [Route("/Contact/SendEmail")]
        public IActionResult SendEmail(ContactViewModel contactVM)
        {
            string subject = "From: " + contactVM.EmailerEmail;
            string body = "From: " + contactVM.EmailerEmail + "<br>" + 
                "Sender: " + contactVM.EmailerName + "<br><br>" +
                "Subject: " + contactVM.EmailerTitle + "<br><br>" + 
                contactVM.EmailerBody;

            MailMessage mail = new MailMessage();
            mail.From = new MailAddress(emailAddress);
            mail.To.Add(emailAddress);
            mail.Subject = subject;
            mail.Body = body;
            mail.IsBodyHtml = true;

            SmtpClient smtp = new SmtpClient(smtpAddress, portNumber);
            smtp.Credentials = new NetworkCredential(emailAddress, password);
            smtp.EnableSsl = enableSSL;
            smtp.Send(mail);

            return RedirectToAction("Index", "Contact");
        }
    }
}
