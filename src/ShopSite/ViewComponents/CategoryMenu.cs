using Microsoft.AspNetCore.Mvc;
using ShopSite.Services;
using ShopSite.ViewModels;

namespace ShopSite.ViewComponents
{
    public class CategoryMenu : ViewComponent
    {
        private ICategoryService _categoryData;

        public CategoryMenu(ICategoryService categoryData)
        {
            _categoryData = categoryData;
        }

        public IViewComponentResult Invoke()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryData.GetAll()
            };

            return View(model);
        }
    }
}
