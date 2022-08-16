using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWebsiteApp.Models
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Company { get; set; }
        public string? Years { get; set; }
        public string? Description { get; set; }
        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
    }
}
