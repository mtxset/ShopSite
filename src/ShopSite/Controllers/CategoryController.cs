using Microsoft.AspNetCore.Mvc;
using ShopSite.Services;
using ShopSite.ViewModels;

namespace ShopSite.Controllers
{
    public class CategoryController : Controller
    {
        private ICategoryService _categoryData;

        public CategoryController(ICategoryService categoryData)
        {
            _categoryData = categoryData;
        }

        public ViewResult Index()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryData.GetAll()
            };

            return View(model);
        }
    }
}
