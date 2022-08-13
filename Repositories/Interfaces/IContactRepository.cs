namespace PortfolioWebsiteApp.Repositories.Interfaces
{
    public interface IContactRepository
    {
        public void InitContact();
        public int Count();
        public string GetCity();
        public string GetRegion();
        public string GetCountry();
        public string GetEmail();
        public bool SaveCity(string newCity);
        public bool SaveRegion(string newRegion);
        public bool SaveCountry(string newCountry);
        public bool SaveEmail(string newEmail);
        public bool Save();
    }
}
