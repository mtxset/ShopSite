using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Http;

namespace ShopSite.Localization.Controllers
{
    public class LocalizationController : Controller
    {
        // GET: /<controller>/
        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append
                (
                    CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions { Expires = DateTime.UtcNow.AddMonths(3) }
                );

            return LocalRedirect(returnUrl);
        }
    }
}
