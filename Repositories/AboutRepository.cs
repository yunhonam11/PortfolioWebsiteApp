using PortfolioWebsiteApp.Data;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Repositories.Interfaces;

namespace PortfolioWebsiteApp.Repositories
{
    public class AboutRepository : IAboutRepository
    {
        private readonly ApplicationDbContext _context;

        public AboutRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // DbSet<About> always holds only 1 main About Model, when this project is deployed, this method
        // must always be run EXACTLY ONCE first before anything else to operate About Page.
        public bool InitAbout()
        {
            About aboutInit = new About
            {
                Title = "Placeholder",
                Body = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."
            };

            _context.About.Add(aboutInit);
            return Save();
        }

        public int Count()
        {
            return _context.About.Count();
        }

        public bool SaveTitle(string title)
        {
            _context.About.First().Title = title;
            return Save();
        }

        public string GetTitle()
        {
            return _context.About.First().Title;
        }

        public bool SaveBody(string body)
        {
            _context.About.First().Body = body;
            return Save();
        }

        public string GetBody()
        {
            return _context.About.First().Body;
        }

        public bool SavePictureUrl(string pictureUrl)
        {
            Logo logo = new Logo
            {
                Picture = pictureUrl
            };
            _context.Logos.Add(logo);

            return Save();
        }

        public ICollection<string> GetPictureUrls()
        {
            ICollection<string> pictureUrls = new List<string>();

            var logos = _context.Logos;
            if (logos != null)
            {
                List<Logo> logosList = logos.ToList();
                for (int i = 0; i < logosList.Count; i++)
                {
                    pictureUrls.Add(logosList[i].Picture);
                }
            }

            return pictureUrls;
        }

        public void RemoveAllLogos()
        {
            while (_context.Logos.Count() != 0)
            {
                _context.Logos.Remove(_context.Logos.First());
                Save();
            }
        }

        public bool Save()
        {
            int result = _context.SaveChanges();
            return result > 0;
        }
    }
}
