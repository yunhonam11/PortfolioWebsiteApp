using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsiteApp.Models
{
    public class Logo
    {
        [Key]
        public int Id { get; set; }
        public string? Picture { get; set; }
    }
}
