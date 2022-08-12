namespace PortfolioWebsiteApp.Repositories.Interfaces
{
    public interface IHomeRepository
    {
        public bool InitHome();
        public int Count();
        public string GetTitle();
        public string GetBody();
        public string GetPictureUrl();
        public bool SaveTitle(string title);
        public bool SaveBody(string body);
        public bool SavePictureUrl(string pictureUrl);
        public bool Save();
    }
}
