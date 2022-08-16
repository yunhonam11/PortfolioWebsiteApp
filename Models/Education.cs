using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWebsiteApp.Models
{
    public class Education
    {
        [Key]
        public int Id { get; set; }
        public string? Type { get; set; }
        public string? Diploma { get; set; }
        public string? Years { get; set; }
        public string? School { get; set; }
        [ForeignKey("Resume")]
        public int ResumeId { get; set; }
    }
}
