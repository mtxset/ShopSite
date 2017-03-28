using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopSite.ViewModels.Product
{
    public class ProductListViewModel
    {
        public IEnumerable<Models.Product> Products { get; set; }

        public Models.Product Product { get; set; }

        public IEnumerable<SelectListItem> ConvertedProducts { get; set; }
    }
}
