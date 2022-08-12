using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortfolioWebsiteApp.Models
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public bool? IsEmailConfirmed { get; set; }
        public string? ProfilePicture { get; set; }
        public string? ProfilePictureNav { get; set; }
        public string? ProfileDescription { get; set; }
        [DataType(DataType.PhoneNumber)]
        public override string? PhoneNumber { get; set; }
        [DataType(DataType.Date)]
        public string? BirthDate { get; set; }
        [ForeignKey("Address")]
        public int? AddressID { get; set; }
        public Address? Address { get; set; }
    }
}
