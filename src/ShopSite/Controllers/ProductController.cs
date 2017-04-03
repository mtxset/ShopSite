using Microsoft.AspNetCore.Mvc;
using ShopSite.Services;
using ShopSite.ViewModels;
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

        public IActionResult ProductsByCategory(int id, SearchOptions searchOptions)
        {
            var category = _categoryRepo.GetCategory(id);

            if (category == null)
                return RedirectToAction("Index");

            var model = new ProductsByCategoryVM()
            {
                CategoryId = category.Id,
                ParentCategoryId = category.ParentId,
                CategoryName = category.Name,
                SeachOptions = searchOptions
            };

            var q = _productRepo.GetByCategory(id);

            model.MaxPrice = q.Max(x => x.Price);
            model.MinPrice = q.Min(x => x.Price);

            model.TotalProducts = q.Count();

            if (searchOptions.MinPrice.HasValue)
                q = q.Where(x => x.Price >= searchOptions.MinPrice.Value);

            if (searchOptions.MaxPrice.HasValue)
                q = q.Where(x => x.Price <= searchOptions.MaxPrice.Value);

            // TODO: prob should be in SQL query   

            var products = q.Select(x => new ProductPreview
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                StockQuantity = x.StockQuantity,
                ShortDescription = x.ShortDescription

            }).ToList();

            // Does not load descriptions

            model.Products = products;

            return View(model);
        }
    }
}
