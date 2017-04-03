using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopSite.ViewModels.Category
{
    public class CategoryListViewModel
    {
        public IEnumerable<Models.Category> Categories { get; set; }

        public Models.Category Category { get; set; }

        /// <summary>
        /// Fills SelectListItem with categories. (Name = Name, Value = Id)
        /// </summary>
        public IEnumerable<SelectListItem> ConvertedCategories { get; set; }
    }
}
