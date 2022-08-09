using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsiteApp.Models.ViewModels
{
    public class RegisterViewModel
    {
        [Required]
        [StringLength(15, ErrorMessage = "First Name must be at least 2 characters long and less than 16 characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please.")]
        public string? FirstName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Last Name must be at least 2 characters long and less than 16 characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-Z]+$", ErrorMessage = "Use letters only please.")]
        public string? LastName { get; set; }
        [Required]
        [StringLength(15, ErrorMessage = "Username must be at least 5 characters long and less than 15 characters long.", MinimumLength = 5)]
        public string? UserName { get; set; }
        [Required]
        [EmailAddress]
        public string? EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [StringLength(15, ErrorMessage = "Password length must be between 6 to 15.", MinimumLength = 6)]
        public string? Password { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Passwords must match.")]
        public string? ConfirmPassword { get; set; }
    }
}
