namespace PortfolioWebsiteApp.Models.ViewModels
{
    public class AboutViewModel
    {
        public string? Title { get; set; }
        public string? Body { get; set; }
        public IEnumerable<string>? Logos { get; set; }
        public IFormFile? LogoFile { get; set; }
    }
}
