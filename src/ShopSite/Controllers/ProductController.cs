using Microsoft.AspNetCore.Mvc;
using ShopSite.Services;
using ShopSite.ViewModels;
using System;
using System.Globalization;
using System.Linq;

namespace ShopSite.Controllers
{
    public class ProductController : Controller
    {
        private ICategoryService _categoryRepo;
        private IProductService _productRepo;

        public ProductController(
            ICategoryService categoryRepo,
            IProductService productRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
        }

        public IActionResult ProductsByCategory(int id, int? page)
        {
            // TODO: weak
            int? searchMaxPrice = null;
            int? searchMinPrice = null;
            
            if (Request.Query.Count > 0)
            {
                var MaxPrice = Request.Query["searchMaxPrice"][0];
                var MinPrice = Request.Query["searchMinPrice"][0];

                if (!string.IsNullOrEmpty(MinPrice))
                    searchMinPrice = (int)Convert.ToDouble(MinPrice, CultureInfo.InvariantCulture.NumberFormat);

                if (!string.IsNullOrEmpty(MaxPrice))
                    searchMaxPrice = (int)Convert.ToDouble(MaxPrice, CultureInfo.InvariantCulture.NumberFormat);
            }

            var category = _categoryRepo.GetCategory(id);

            if (category == null)
                return RedirectToAction("Index");

            var model = new ProductsByCategoryVM()
            {
                CategoryId = category.Id,
                ParentCategoryId = category.ParentId,
                CategoryName = category.Name,
            };

            var q = _productRepo.GetByCategory(id);

            model.MaxPrice = q.Max(x => x.Price);
            model.MinPrice = q.Min(x => x.Price);

            if (searchMaxPrice != null)
            {
                model.SearchMaxPrice = searchMaxPrice;
                q = q.Where(x => x.Price <= searchMaxPrice);
            }

            if (searchMinPrice != null)
            {
                model.SearchMinPrice = searchMinPrice;
                q = q.Where(x => x.Price >= searchMinPrice);
            }

            model.TotalProducts = q.Count();

            

            // TODO: prob should be in SQL query search by price
            var products = q.Select(x => new ProductPreview
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                StockQuantity = x.StockQuantity,
                ShortDescription = x.ShortDescription

            }).ToList();

            model.Products = products;

            return View(model);
        }
    }
}
