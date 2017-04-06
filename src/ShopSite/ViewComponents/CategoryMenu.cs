using Microsoft.AspNetCore.Mvc;
using ShopSite.Models;
using ShopSite.Services;
using ShopSite.ViewModels.Category;
using System.Collections.Generic;
using System.Linq;

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
            
            var categories = _categoryData.GetAll();

            var categoryMenuItems = new List<CategoryMenuItem>();

            foreach (var item in categories.Where(x=>!x.ParentId.HasValue))
            {
                var categoryMenuItem = Map(item);
                categoryMenuItems.Add(categoryMenuItem);
            }

            return View(categoryMenuItems);
        }

        private CategoryMenuItem Map(Category category)
        {
            var categoryMenuItem = new CategoryMenuItem
            {
                Id = category.Id,
                Name = category.Name
            };

            var childCategories = category.Children;
            foreach (var childCategory in childCategories)
            {
                var childCategoryMenuItem = Map(childCategory);
                categoryMenuItem.AddChildItem(childCategoryMenuItem);
            }

            return categoryMenuItem;
        }
    }
}
