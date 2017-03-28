using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopSite.Models;
using ShopSite.Services;
using ShopSite.ViewModels;
using ShopSite.ViewModels.Admin;
using ShopSite.ViewModels.Category;
using ShopSite.ViewModels.Product;

namespace ShopSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ICategoryService _categoryRepo;
        private IProductService _productRepo;

        public AdminController(ICategoryService categoryRepo, IProductService productRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Products()
        {
            var model = new ProductListViewModel()
            {
                Products = _productRepo.GetAll()
            };

            return View("~/Views/Admin/Products/Products.cshtml", model);
        }

        public ViewResult Categories()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryRepo.GetAll()
            };

            return View("~/Views/Admin/Categories/Categories.cshtml", model);
        }

        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View("~/Views/Admin/Categories/Create.cshtml");
        }

        [HttpGet]
        public IActionResult ProductCreate()
        {
            return View("~/Views/Admin/Products/Create.cshtml");
        }

        public IActionResult ProductRemove(int id)
        {
            var product = _productRepo.Get(id);

            _productRepo.Remove(product);
            _productRepo.Commit();

            return RedirectToAction("Index");
        }

        //[HttpDelete]
        public IActionResult CategoryRemove(int id)
        {
            var category = _categoryRepo.GetCategory(id);

            _categoryRepo.Remove(category);
            _categoryRepo.Commit();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ProductCreate(ProductEdit model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Admin/Products/Create.cshtml");

            var product = new Product
            {
                Name = model.Product.Name,
                ShortDescription = model.Product.ShortDescription,
                Description = model.Product.Description,
                Price = model.Product.Price,
                StockQuantity = model.Product.StockQuantity,
                IsAllowedToOrder = model.Product.IsAllowedToOrder,
                IsFeatured = model.Product.IsFeatured
                //Categories = model.Categories
            };

            _productRepo.Create(product);
            _productRepo.Commit();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CategoryCreate(CategoryEdit model)
        {
            if (!User.IsInRole("Admin")) return View();

            if (!ModelState.IsValid)
                return View("~/Views/Admin/Categories/Create.cshtml");

            var category = new Category
            {
                Name = model.Name,
                Description = model.Description
            };

            _categoryRepo.Create(category);
            _categoryRepo.Commit();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CategoryEdit(int id, CategoryEdit model)
        {
            var category = _categoryRepo.GetCategory(id);

            if (ModelState.IsValid && category != null)
            {
                category.Name = model.Name;
                category.Description = model.Description;
                category.ParentId = model.ParentId;

                _categoryRepo.Commit();

                return RedirectToAction("Index");
            }

            return View("~/Views/Admin/Categories/Edit.cshtml");
        }

        [HttpPost]
        public IActionResult ProductEdit(int id, )

        [HttpGet]
        public IActionResult ProductEdit(int id)
        {
            var model = new ProductEdit();

            var product = _productRepo.Get(id);

            model.Product = product;

            return View("~/Views/Admin/Products/Edit.cshtml", model);
        }


        [HttpGet]
        public IActionResult CategoryEdit(int id)
        {
            var model = new CategoryEdit();

            var categories = _categoryRepo.GetAll();
            var category = _categoryRepo.GetCategory(id);

            model.Name = category.Name;
            model.Description = category.Description;

            model.ParentId = category.ParentId ?? 0;

            var list = new List<SelectListItem>();

            foreach (var item in categories)
            {
                list.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.ParentId.ToString(),
                    Selected = true
                });
            }

            model.Categories = list;

            return View("~/Views/Admin/Categories/Edit.cshtml", model);
        }
    }
}
