using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopSite.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using System.IdentityModel.Claims;

namespace ShopSite.Services
{
    public class WorkContext : IWorkContext
    {
        private const string UserGuidCookieName = "ShopSiteGuid";

        private User _currentUser;
        private UserManager<User> _userManager;
        private HttpContext _httpContext;

        public WorkContext(UserManager<User> userManager, IHttpContextAccessor httpContextAccessor)
        {
            _userManager = userManager;
            _httpContext = httpContextAccessor.HttpContext;
        }

        public async Task<User> GetCurrentUser()
        {
            var user = _httpContext.User.Identity;

            if (_currentUser != null)
                return _currentUser;

            if (_httpContext.User.Identity.AuthenticationType == "Identity.Application")
            {
                var contextUser = _httpContext.User;
                _currentUser = await _userManager.GetUserAsync(contextUser);
            }

            if (_currentUser != null)
                return _currentUser;

            // Getting User from cookies
            Guid? userGuid;
            if (_httpContext.Request.Cookies.ContainsKey(UserGuidCookieName))
                userGuid = Guid.Parse(_httpContext.Request.Cookies[UserGuidCookieName]);
            else
                userGuid = null;

            return _currentUser;
           
        }
    }
}
