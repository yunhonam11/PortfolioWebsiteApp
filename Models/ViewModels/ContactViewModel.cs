using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsiteApp.Models.ViewModels
{
    public class ContactViewModel
    {
        [Required]
        public string? City { get; set; }
        [Required]
        public string? Region { get; set; }
        [Required]
        public string? Country { get; set; }
        [DataType(DataType.EmailAddress)]
        public string? EmailAddress { get; set; }
        [Required]
        public string? EmailerName { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        public string? EmailerEmail { get; set; }
        public string? EmailerTitle { get; set; }
        public string? EmailerBody { get; set; }
    }
}
