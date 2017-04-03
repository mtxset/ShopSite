using Microsoft.AspNetCore.Mvc;
using ShopSite.Services;
using ShopSite.ViewModels;
using System.Linq;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSite
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
