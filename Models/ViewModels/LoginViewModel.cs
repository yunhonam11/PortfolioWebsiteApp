using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsiteApp.Models.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string? Password { get; set; }
        public string? RememberMe { get; set; }
    }
}
