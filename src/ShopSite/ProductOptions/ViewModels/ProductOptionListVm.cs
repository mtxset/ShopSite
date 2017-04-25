using ShopSite.ProductOptions.Models;
using ShopSite.Services;
using System.Collections.Generic;

namespace ShopSite.ProductOptions.ViewModels
{
    public class ProductOptionListVm
    {
        public IPagedList<ProductOption> Options { get; set; }
    }
}
