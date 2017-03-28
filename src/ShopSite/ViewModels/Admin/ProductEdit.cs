using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopSite.ViewModels.Admin
{
    public class ProductEdit
    {
        public Models.Product Product { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } 
        
        public IList<bool> SelectedCategories { get; set; }
    }
}
