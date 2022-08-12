using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsiteApp.Models
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
        public IEnumerable<String>? Logos { get; set; }
    }
}
