using PortfolioWebsiteApp.Data;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Repositories.Interfaces;

namespace PortfolioWebsiteApp.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;

        public ContactRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public void InitContact()
        {
            Contact contact = new Contact
            {
                City = "Toronto",
                Region = "Ontario",
                Country = "Canada",
                EmailAddress = "namyun.toronto@gmail.com"
            };

            _context.Contact.Add(contact);
            Save();
        }

        public int Count()
        {
            return _context.Contact.Count();
        }

        public string GetCity()
        {
            return _context.Contact.First().City;
        }

        public string GetRegion()
        {
            return _context.Contact.First().Region;
        }

        public string GetCountry()
        {
            return _context.Contact.First().Country;
        }

        public string GetEmail()
        {
            return _context.Contact.First().EmailAddress;
        }

        public bool SaveCity(string newCity)
        {
            _context.Contact.First().City = newCity;
            return Save();
        }

        public bool SaveRegion(string newRegion)
        {
            _context.Contact.First().Region = newRegion;
            return Save();
        }

        public bool SaveCountry(string newCountry)
        {
            _context.Contact.First().Country = newCountry;
            return Save();
        }

        public bool SaveEmail(string newEmail)
        {
            _context.Contact.First().EmailAddress = newEmail;
            return Save();
        }

        public bool Save()
        {
            var result = _context.SaveChanges();
            return result > 0;
        }
    }
}
