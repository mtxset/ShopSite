using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopSite.Models;
using System.Threading.Tasks;

namespace ShopSite.Data
{
    public class AdminRoleSeed
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private IConfiguration _config;

        public AdminRoleSeed(RoleManager<IdentityRole> roleManager, UserManager<User> userManager, IConfiguration config)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _config = config;
        }

        public async Task EnsureAdminSeed()
        {
            string adminName = _config.GetValue<string>("AdminUserName");

            if (await _userManager.FindByNameAsync(adminName) != null)
            {
                await _roleManager.CreateAsync(new IdentityRole("admin"));

                User user = await _userManager.FindByNameAsync(adminName);
                
                IdentityResult result = await _userManager.AddToRoleAsync(user, "admin");
            }
        }
    }
}
