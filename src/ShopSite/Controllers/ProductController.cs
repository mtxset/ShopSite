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

        public IActionResult ProductsByCategory(int id, ProductsByCategoryVM readModel)
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
            //is features/publiushed

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

            if (readModel.SearchOptions.PageSize == 0) readModel.SearchOptions.PageSize = 2;

            int currentPageNumber = readModel.SearchOptions.Page <= 0 ? 1 : readModel.SearchOptions.Page;
            int offset = (readModel.SearchOptions.PageSize * currentPageNumber) - readModel.SearchOptions.PageSize;

            while (currentPageNumber > 1 && offset >= model.TotalProducts)
            {
                currentPageNumber--;
                offset = (readModel.SearchOptions.PageSize * currentPageNumber) - readModel.SearchOptions.PageSize;
            }

            var products = q.Select(x => new ProductPreview
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                StockQuantity = x.StockQuantity,
                ShortDescription = x.ShortDescription

            }).Skip(offset).Take(readModel.SearchOptions.PageSize).ToList();

            model.Products = products;

            model.SearchOptions.PageSize = readModel.SearchOptions.PageSize;
            model.SearchOptions.Page = currentPageNumber;

            return View(model);
        }
    }
}
