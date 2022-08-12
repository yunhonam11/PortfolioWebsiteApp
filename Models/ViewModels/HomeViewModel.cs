namespace PortfolioWebsiteApp.Models.ViewModels
{
    public class HomeViewModel
    {
        public IFormFile? PictureFile { get; set; }
        public string? Picture { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }

    }
}
