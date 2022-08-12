﻿using PortfolioWebsiteApp.Data;
using PortfolioWebsiteApp.Models;
using PortfolioWebsiteApp.Repositories.Interfaces;

namespace PortfolioWebsiteApp.Repositories
{
    public class HomeRepository : IHomeRepository
    {
        private readonly ApplicationDbContext _context;

        public HomeRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        // DbSet<Home> always holds only 1 main Home Model, when this project is deployed, this method
        // must always be run EXACTLY ONCE first before anything else to operate Home Page.
        public bool InitHome()
        {
            Home homeInit = new Home
            {
                Picture = "data:image/jpeg;base64,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",
                Title = "Placeholder",
                Body = "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book."
            };
            _context.Home.Add(homeInit);
            return Save();
        }

        public int Count()
        {
            return _context.Home.Count();
        }

        public string GetTitle()
        {
            return _context.Home.First().Title;
        }

        public string GetBody()
        {
            return _context.Home.First().Body;
        }

        public string GetPictureUrl()
        {
            return _context.Home.First().Picture;
        }

        public bool SaveTitle(string title)
        {
            _context.Home.First().Title = title;
            return Save();
        }

        public bool SaveBody(string body)
        {
            _context.Home.First().Body = body;
            return Save();
        }

        public bool SavePictureUrl(string pictureUrl)
        {
            _context.Home.First().Picture = pictureUrl;
            return Save();
        }

        public bool Save()
        {
            int result = _context.SaveChanges();
            return result > 0;
        }
    }
}
