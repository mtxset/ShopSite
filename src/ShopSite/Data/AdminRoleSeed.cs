using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ShopSite.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.Data
{
    public class AdminRoleSeed
    {
        private RoleManager<IdentityRole> _roleManager;
        private UserManager<User> _userManager;
        private IConfiguration _config;
        private ILogger _logger;

        public AdminRoleSeed(
            ILoggerFactory logger,
            RoleManager<IdentityRole> roleManager,
            UserManager<User> userManager,
            IConfiguration config)
        {
            _roleManager = roleManager;
            _userManager = userManager;
            _config = config;
            _logger = logger.CreateLogger("AdminRoleSeed");
        }

        public async Task EnsureAdminSeed()
        {
            var adminNames = _config.GetSection("AdminUserNames").GetChildren().Select(x => x.Value).ToList();
            var roleNames = _config.GetSection("UserRoles").GetChildren().Select(x => x.Value).ToList();

            var list = new List<string>();

            foreach (var adminName in adminNames)
            {
                if (await _userManager.FindByNameAsync(adminName) != null)
                {
                    foreach (var item in roleNames)
                    {
                        await _roleManager.CreateAsync(new IdentityRole(item));
                        list.Add(item);
                    }

                    if (!string.IsNullOrEmpty(adminName))
                    {
                        var user = await _userManager.FindByNameAsync(adminName);

                        IdentityResult result = await _userManager.AddToRoleAsync(user, "admin");
                    }
                    else { _logger.LogError("Admin name could't be found"); }
                }
            }

            _logger.LogInformation("Roles and admin user were assigned");
        }
    }
}
