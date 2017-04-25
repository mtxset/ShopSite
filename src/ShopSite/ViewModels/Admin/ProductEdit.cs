using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using ShopSite.ProductOptions.ViewModels;

namespace ShopSite.ViewModels.Admin
{
    public class ProductEdit
    {
        public Models.Product Product { get; set; }

        public IList<SelectListItem> Categories { get; set; } 
        
        public IList<bool> SelectedCategories { get; set; }

        public bool EditImageUrl { get; set; }

        public IFormFile File { get; set; }

        public IList<ProductOptionVm> Options { get; set; }
    }
}
