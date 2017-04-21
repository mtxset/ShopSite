using Microsoft.AspNetCore.Mvc;
using ShopSite.Models;
using ShopSite.Search.ViewModels;
using ShopSite.Services;
using ShopSite.ViewModels;

using System.Linq;

namespace ShopSite.Search.Controllers
{
    public class SearchController : Controller
    {
        private IProductService _productRepo;

        public SearchController(IProductService productService)
        {
            _productRepo = productService;
        }

        public IActionResult Index(SearchResultsVm readModel)
        {
            ViewData["CurrentSort"] = readModel.SortOrder;
            ViewData["PriceSortParm"] = readModel.SortOrder == "price" ? "price_desc" : "price";

            if (readModel.SearchString != null)
                readModel.Page = 0;
            else
                readModel.SearchString = readModel.CurrentFilter;

            ViewData["CurrentFilter"] = readModel.SearchString;

            var q = _productRepo.QueryableProduct();

            if (!string.IsNullOrEmpty(readModel.SearchString))
                q = q.Where(x => x.IsFeatured).Where(x => x.Name.Contains(readModel.SearchString));
            else
                q = q.Where(x => x.IsFeatured);

            var model = new SearchResultsVm();

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

            var products = q.Select(x => new ProductPreview
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                StockQuantity = x.StockQuantity,
                ShortDescription = x.ShortDescription,
                ImageUrl = x.ImageUrl
            }).ToList();

            model.Products = new PagedList<ProductPreview>(products, readModel.IndexPage ?? 0, 25); // TODO: read from config

            return View(model);
        }
    }
}