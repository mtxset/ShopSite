﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopSite.Models;
using ShopSite.Services;
using ShopSite.ViewModels;
using System.IO;
using System.Linq;

namespace ShopSite.Controllers
{
    public class ProductController : Controller
    {
        private ICategoryService _categoryRepo;
        private IProductService _productRepo;
        private int _pageSize;

        public ProductController(
            ICategoryService categoryRepo,
            IProductService productRepo,
            IConfiguration config)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _pageSize = config.GetValue<int>("ProductsPageSize");
        }

        public IActionResult Search(string query)
        {
            if (string.IsNullOrEmpty(query))
                return View();

            var q = _productRepo.QueryProduct().Cast<Product>();

            q = q.Where(x => x.Name.Contains(query) && x.IsFeatured);

            return View();
        }

        public IActionResult ProductsByCategory(int id, ProductsByCategoryVM readModel)
        {
            var v = ViewBag.PageSize;
            var category = _categoryRepo.GetCategory(id);

            if (category == null)
                return RedirectToAction("Index");

            var model = new ProductsByCategoryVM()
            {
                CategoryId = category.Id,
                ParentCategoryId = category.ParentId,
                CategoryName = category.Name,
            };

            var q = _productRepo.GetByCategory(id).Where(x => x.IsFeatured);

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
            
            if (readModel.SearchOptions.PageSize == 0) readModel.SearchOptions.PageSize = _pageSize;

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
                ShortDescription = x.ShortDescription,
                ImageUrl = x.ImageUrl

            }).Skip(offset).Take(readModel.SearchOptions.PageSize).ToList();

            model.Products = products;

            model.SearchOptions.PageSize = readModel.SearchOptions.PageSize;
            model.SearchOptions.Page = currentPageNumber;

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var q = _productRepo.QueryableProduct();

            var model = q.Include(x => x.OptionValues)
                .FirstOrDefault(x => x.Id == id);

            return View(model);
        }
    }
}
