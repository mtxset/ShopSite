using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopSite.Services;

namespace ShopSite.ViewModels.Product
{
    public class ProductListViewModel
    {
        public SearchOptions SearchOptions { get; set; }

        public int IndexPage { get; set; }
        public IPagedList<Models.Product> Products { get; set; }

        public Models.Product Product { get; set; }

        public IEnumerable<SelectListItem> ConvertedProducts { get; set; }
    }
}
