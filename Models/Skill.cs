using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWebsiteApp.Models
{
    public class Skill
    {
        [Key]
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Name { get; set; }
        public string? List { get; set; }
        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
    }
}
