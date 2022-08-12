using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsiteApp.Models
{
    public class Home
    {
        [Key]
        public int Id { get; set; }
        public string? Picture { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
    }
}
