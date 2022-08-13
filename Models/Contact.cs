using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsiteApp.Models
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        public string? City { get; set; }
        public string? Region { get; set; }
        public string? Country { get; set; }
        public string? EmailAddress { get; set; }
    }
}
