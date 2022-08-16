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
        public DbSet<Skill> Skills { get; set; }
        public DbSet<Education> Educations { get; set; }
        public DbSet<Experience> Experiences { get; set; }
        public DbSet<Resume> Resumes { get; set; }
        public DbSet<Contact> Contact { get; set; }
        public DbSet<Home> Home { get; set; }
        public DbSet<About> About { get; set; }
        public DbSet<Logo> Logos { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
