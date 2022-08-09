using Microsoft.EntityFrameworkCore;
using PortfolioWebsiteApp.Data;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Repositories.Interfaces;

namespace PortfolioWebsiteApp.Repositories
{
    public class AddressRepository : IAddressRepository
    {
        private readonly ApplicationDbContext _context;

        public AddressRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(Address address)
        {
            _context.Add(address);
            return Save();
        }

        public IEnumerable<Address> GetAll()
        {
            return _context.Addresses.ToArray();
        }

        public Address GetById(int? id)
        {
            return _context.Addresses.Find(id);
        }

        public int GetCount()
        {
            return _context.Addresses.Count();
        }

        public void RemoveAll()
        {
            while (GetCount() != 0)
            {
                _context.Remove(_context.Addresses.First());
                Save();
            }
        }

        public void RemoveById(int? id)
        {
            _context.Remove(GetById(id));
        }

        public bool Save()
        {
            int result = _context.SaveChanges();
            return result > 0;
        }

        public bool Update(Address address)
        {
            _context.Update(address);
            return Save();
        }
    }
}
