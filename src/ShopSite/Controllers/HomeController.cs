using Microsoft.AspNetCore.Mvc;
using ShopSite.Services;
using ShopSite.ViewModels;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSite
{
    public class HomeController : Controller
    {
        private IProductService _productRepo;

        public HomeController(IProductService productservice)
        {
            _productRepo = productservice;
        }

        public IActionResult Index()
        {
            Random r = new Random();
            List<int> ids = new List<int>();
            
            for(int i = 0; i< 9; i++)
            {
                ids.Add(r.Next(1, 30));
            }
            var q = _productRepo.GetByListOfIds(ids);

            var products = q.Select(x => new ProductPreview
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                StockQuantity = x.StockQuantity,
                ShortDescription = x.ShortDescription,
                ImageUrl = x.ImageUrl

            }).ToList();
  
            return View(products);
        }
    }
}
