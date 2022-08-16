using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsiteApp.Models
{
    public class Resume
    {
        [Key]
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? PicUrl { get; set; }
        public string? AboutMe { get; set; }
        public string? Objective { get; set; }
    }
}
