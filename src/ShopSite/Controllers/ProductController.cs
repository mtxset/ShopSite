using Microsoft.AspNetCore.Mvc;
using ShopSite.Models;
using ShopSite.Pagination;
using ShopSite.Services;
using ShopSite.ViewModels;
using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

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

        public async Task<IActionResult> ProductsByCategory(int id, ProductsByCategoryVM readModel)
        {
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

            if (readModel.SearchMaxPrice.HasValue)
            { 
                q = q.Where(x => x.Price <= readModel.SearchMaxPrice);
                model.SearchMaxPrice = readModel.SearchMaxPrice;
            }

            if (readModel.SearchMinPrice.HasValue)
            { 
                q = q.Where(x => x.Price >= readModel.SearchMinPrice);
                model.SearchMinPrice = readModel.SearchMinPrice;
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

            int pageSize = 2;

            var job = await PaginatedList<Product>.CreateAsync(q, readModel.Page ?? 1, pageSize);

            return View(model);
        }
    }
}
