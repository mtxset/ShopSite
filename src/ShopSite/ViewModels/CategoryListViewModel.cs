using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopSite.Models;

namespace ShopSite.ViewModels
{
    public class CategoryListViewModel
    {
        public IEnumerable<Category> Categories { get; set; }

        public Category Category { get; set; }

        public IEnumerable<SelectListItem> ConvertedCategories { get; set; }
    }
}
