using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopSite.Data.Repository;
using ShopSite.ProductOptions.Models;
using Microsoft.AspNetCore.Authorization;
using ShopSite.ProductOptions.ViewModels;
using ShopSite.Services;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace ShopSite.ProductOptions.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductOptionController : Controller
    {
        private readonly IRepository<ProductOption> _productOptionRepo;

        public ProductOptionController(
            IRepository<ProductOption> productOptionRepo)
        {
            _productOptionRepo = productOptionRepo;
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _productOptionRepo.Table
                .FirstOrDefault(x => x.Id == id);

            return View("~/ProductOptions/Views/Admin/Edit.cshtml", model);
        }

        [HttpPost]
        public IActionResult Edit(int id, ProductOption edit)
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create(ProductOption model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Create");

            _productOptionRepo.Insert(model);

            return RedirectToAction("Admin");
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View("~/ProductOptions/Views/Admin/Create.cshtml");
        }

        [HttpGet]
        public IActionResult Admin()
        {
            var model = new ProductOptionListVm();

            var q = _productOptionRepo.Table;

            model.Options = new PagedList<ProductOption>(q.ToList(), 0, 100);

            return View("~/ProductOptions/Views/Admin/ProductOptions.cshtml", model);
        }
    }
}
