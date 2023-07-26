using Microsoft.AspNetCore.Identity;
using OnlineShop.Db.Models;

namespace OnlineShop.Db
{
    public class IdentityInitializer
    {
        public static void Initialize(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            const string adminName = "Admin";
            const string adminEmail = "iamgroot@gmail.com";
            const string password = "1123581321_Ajax";

            if (roleManager.FindByNameAsync(Constant.AdminRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constant.AdminRoleName)).Wait();
            }

            if (roleManager.FindByNameAsync(Constant.UserRoleName).Result == null)
            {
                roleManager.CreateAsync(new IdentityRole(Constant.UserRoleName)).Wait();
            }

            if (userManager.FindByEmailAsync(adminEmail).Result != null) return;

            var admin = new User() { Email = adminEmail, UserName = adminName };
            var result = userManager.CreateAsync(admin, password).Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(admin, Constant.AdminRoleName).Wait();
            }
        }
    }
}
