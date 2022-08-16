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
                await userManager.CreateAsync(newAppAdmin, "");
                await userManager.AddToRoleAsync(newAppAdmin, "Admin");
            }

            // user 1
            var user1 = new AppUser()
            {
                Name = "Tester One",
                UserName = "tester1",
                Email = "pokemon1@gmail.com",
                IsEmailConfirmed = true
            };
            await userManager.CreateAsync(user1, "123456noho");
            await userManager.AddToRoleAsync(user1, "User");

            // user 2
            var user2 = new AppUser()
            {
                Name = "Tester Two",
                UserName = "tester2",
                Email = "pokemon2@gmail.com",
                IsEmailConfirmed = true
            };
            await userManager.CreateAsync(user2, "123456noho");
            await userManager.AddToRoleAsync(user2, "User");

            // user 3
            var user3 = new AppUser()
            {
                Name = "Tester Three",
                UserName = "tester3",
                Email = "pokemon3@gmail.com",
                IsEmailConfirmed = true
            };
            await userManager.CreateAsync(user3, "123456noho");
            await userManager.AddToRoleAsync(user3, "User");
        }
    }
}
