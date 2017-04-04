using Microsoft.AspNetCore.Mvc;
using ShopSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.ViewComponents
{
    public class SearchPanel : ViewComponent
    {
        private ICategoryService _categoryService;
        private IProductService _productService;

        public SearchPanel(ICategoryService categoryService, IProductService productService)
        {
            _categoryService = categoryService;
            _productService = productService;
        }

        public IViewComponentResult Invoke()
        {
            // TODO: Unique Search for product and category
            return View();
        }
    }
}

