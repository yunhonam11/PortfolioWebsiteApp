namespace PortfolioWebsiteApp.Repositories.Interfaces
{
    public interface IAboutRepository
    {
        public bool InitAbout();
        public int Count();
        public bool SaveTitle(string title);
        public string GetTitle();
        public bool SaveBody(string body);
        public string GetBody();
        public bool SavePictureUrl(string pictureUrl);
        public ICollection<string> GetPictureUrls();
        public void RemoveAllLogos();
        public bool Save();
    }
}
