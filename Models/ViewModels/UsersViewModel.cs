namespace PortfolioWebsiteApp.Models.ViewModels
{
    public class UsersViewModel
    {
        public ICollection<string>? adminUsernames { get; set; }
        public ICollection<string>? adminNames { get; set; }
        public ICollection<string>? userUsernames { get; set; }
        public ICollection<string>? userNames { get; set; }
    }
}
