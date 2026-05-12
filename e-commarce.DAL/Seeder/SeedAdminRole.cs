using ecommarce.DAL.models;
using Microsoft.AspNetCore.Identity;

namespace YourProject.Infrastructure.Persistence
{
    public static class DbSeeder
    {
        public static async Task SeedAdminAsync(
            UserManager<AppUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
    
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                await roleManager.CreateAsync(new IdentityRole("Admin"));
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                await roleManager.CreateAsync(new IdentityRole("User"));
            }

          
            string adminEmail = "admin@gmail.com";
            string adminPassword = "Admin@123";
            var admin = await userManager.FindByEmailAsync(adminEmail);

            if (admin == null)
            {
                var adminUser = new AppUser
                {
                    UserName = "admin",
                    Email = "admin@gmail.com",
                    FirstName = "System",
                    LastName = "Admin",
                    EmailConfirmed = true
                };

                var result = await userManager.CreateAsync(adminUser, adminPassword);

                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(adminUser, "Admin");
                }
            }
        }
    }
}