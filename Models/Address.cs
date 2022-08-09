using System.ComponentModel.DataAnnotations;

namespace PortfolioWebsiteApp.Models
{
    public class Address
    {
        [Key]
        public int ID { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? StateOrProvince { get; set; }
        public string? ZipOrPostal { get; set; }
        public string? Country { get; set; }
    }
}
