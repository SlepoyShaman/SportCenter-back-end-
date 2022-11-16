using Microsoft.AspNetCore.Identity;
using SportCenter.Models.DataModels;

namespace SportCenter.Models.Identity
{
    public static class RoleInintializer
    {
        public static async Task InitAsync(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            string adminRoleName = "admin";
            string adminEmail = "admin@sport.center";
            string adminPassword = "admin123";

            if(await roleManager.FindByNameAsync(adminRoleName) == null)
                await roleManager.CreateAsync(new IdentityRole(adminRoleName));
            if(await userManager.FindByNameAsync(adminEmail) == null)
            {
                var admin = new User() { Email = adminEmail, UserName = adminEmail, Membership = new Membership() };
                var result = await userManager.CreateAsync(admin, adminPassword);

                if (result.Succeeded)
                    await userManager.AddToRoleAsync(admin, adminRoleName);
            }
            
        }
    }
}
