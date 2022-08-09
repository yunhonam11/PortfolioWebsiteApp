using Microsoft.AspNetCore.Identity;
using PortfolioWebsiteApp.Models;

namespace PortfolioWebsiteApp.Data
{
    public class Seed
    {
        public static async Task SeedAdminMaker(IApplicationBuilder applicationBuilder)
        {
            var serviceScope = applicationBuilder.ApplicationServices.CreateScope();
            var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

            if (!await roleManager.RoleExistsAsync("Admin"))
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            if (!await roleManager.RoleExistsAsync("User"))
                await roleManager.CreateAsync(new IdentityRole("User"));

            var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<AppUser>>();
            string adminEmail = "namyun.toronto@gmail.com";

            var appAdmin = await userManager.FindByNameAsync(adminEmail);
            if (appAdmin == null)
            {
                var newAppAdmin = new AppUser()
                {
                    Name = "Yunho Nam",
                    UserName = "namyun",
                    Email = adminEmail,
                    IsEmailConfirmed = true,
                };
                await userManager.CreateAsync(newAppAdmin, "123nam!@#$%");
                await userManager.AddToRoleAsync(newAppAdmin, "Admin");
            }
        }
    }
}
