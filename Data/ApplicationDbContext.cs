using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PortfolioWebsiteApp.Models;

namespace PortfolioWebsiteApp.Data
{
    public class ApplicationDbContext : IdentityDbContext<AppUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Home> Home { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
