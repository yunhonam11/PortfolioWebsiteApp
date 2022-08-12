using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;

namespace PortfolioWebsiteApp.Models.ViewModels
{
    public class ProfileViewModel
    {
        public string? Username { get; set; }
        public string? Name { get; set; }
        public string? ProfilePicture { get; set; }
        public string? ProfileDescription { get; set; }
        public IFormFile? ProfilePictureForm { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string? PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public string? BirthDate { get; set; }
        [ForeignKey("Address")]
        public int? AddressID { get; set; }
        public Address? Address { get; set; }
        public string? Street { get; set; }
        public string? City { get; set; }
        public string? StateOrProvince { get; set; }
        public string? ZipOrPostal { get; set; }
        public string? Country { get; set; }
    }
}
