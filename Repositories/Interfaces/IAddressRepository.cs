using PortfolioWebsiteApp.Models;

namespace PortfolioWebsiteApp.Repositories.Interfaces
{
    public interface IAddressRepository
    {
        void RemoveAll();
        void RemoveById(int? id);
        IEnumerable<Address> GetAll();
        Address GetById(int? id);
        int GetCount();
        bool Add(Address address);
        bool Update(Address address);
        bool Save();
    }
}
