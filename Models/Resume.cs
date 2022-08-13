using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsiteApp.Models
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }
        public string? Objective { get; set; }

    }
}
