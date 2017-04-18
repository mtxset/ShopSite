using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopSite.Models;
using ShopSite.Services;
using ShopSite.ViewModels.Admin;
using ShopSite.ViewModels.Category;
using ShopSite.ViewModels.Product;
using ShopSite.Data.Repository;
using System.IO;

namespace ShopSite.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private ICategoryService _categoryRepo;
        private IProductService _productRepo;
        private IRepository<ProductCategory> _productCategoryRepo;

        public AdminController(
            ICategoryService categoryRepo,
            IProductService productRepo,
            IRepository<ProductCategory> productCategoryRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _productCategoryRepo = productCategoryRepo;
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
            var model = new ProductEdit
            {
                Categories = GetAllCategories()
            };

            return View("~/Views/Admin/Products/Create.cshtml", model);

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
                return RedirectToAction("ProductCreate");

            var product = model.Product;

            product.ImageUrl = Path.Combine("/images/", model.Product.ImageUrl);

            var categories = _categoryRepo.GetAll();

            var categoryIds = categories.Select(item => item.Id).ToList();

            var selectedCategoryIds = new List<int>();

            for (var i = 0; i < model.SelectedCategories.Count; i++)
            {
                if (model.SelectedCategories[i])
                {
                    selectedCategoryIds.Add(categoryIds[i]);
                }
            }

            foreach (var item in selectedCategoryIds)
            {
                var productCategory = new ProductCategory
                {
                    CategoryId = item
                };
                product.AddCategory(productCategory);
            }

            _productRepo.Create(product);
            _productRepo.Commit();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult CategoryCreate(Category model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Admin/Categories/Create.cshtml");

            var category = model;

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

                _categoryRepo.Update(category);
                _categoryRepo.Commit();

                return RedirectToAction("Categories");
            }

            return RedirectToAction("CategoryEdit");
        }

        [HttpPost]
        public IActionResult ProductEdit(int id, ProductEdit model)
        {
            var product = _productRepo.GetWithCategories(id);

            if (ModelState.IsValid && product != null)
            {
                product.Name = model.Product.Name;   
                product.Description = model.Product.Description;
                product.ShortDescription = model.Product.ShortDescription;
                product.StockQuantity = model.Product.StockQuantity;
                product.Price = model.Product.Price;
                product.IsAllowedToOrder = model.Product.IsAllowedToOrder;
                product.IsFeatured = model.Product.IsFeatured;

                if (model.EditImageUrl && !string.IsNullOrEmpty(model.Product.ImageUrl))
                    product.ImageUrl = Path.Combine("/images/", model.Product.ImageUrl);

                var categories = _categoryRepo.GetAll();
                var selectedCategoryIds = new List<int>();
                var categoryIds = categories.Select(item => item.Id).ToList();

                for (var i = 0; i < model.SelectedCategories.Count; i++)
                {
                    if (model.SelectedCategories[i])
                    {
                        selectedCategoryIds.Add(categoryIds[i]);
                    }
                }

                foreach (var item in selectedCategoryIds)
                {
                    if (product.Categories.Any(x => x.CategoryId == item))
                    {
                        continue;
                    }

                    var productCategory = new ProductCategory
                    {
                        CategoryId = item
                    };
                    product.AddCategory(productCategory);
                }

                List<ProductCategory> deletedProductCategories = product.Categories
                    .Where(x => !selectedCategoryIds.Contains(x.CategoryId)).ToList();

                foreach (var item in deletedProductCategories)
                {
                    item.Product = null;
                    product.Categories.Remove(item);
                    _productCategoryRepo.Delete(item);
                }

                _productRepo.Update(product);
                _productRepo.Commit();

                return RedirectToAction("Products");
            }

            return RedirectToAction("Index");
            
        }

        [HttpGet]
        public IActionResult ProductEdit(int id)
        {
            var model = new ProductEdit();

            var product = _productRepo.GetWithCategories(id);

            model.Product = product;

            var productCategoryIds = new List<int>();

            foreach (var item in product.Categories)
            {
                productCategoryIds.Add(item.CategoryId);
            }

            var categories = _categoryRepo.GetListByIds(productCategoryIds);
            var list = new List<SelectListItem>();

            foreach (var item in _categoryRepo.GetAll())
            {
                list.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            foreach (SelectListItem selectItem in list)
            {
                foreach (var item in categories.ToList())
                {
                    bool change = Equals(selectItem.Value, item.Id.ToString());
                    if (change) selectItem.Selected = true;
                }
            }

            model.Categories = list;

            return View("~/Views/Admin/Products/Edit.cshtml", model);
        }

        private List<SelectListItem> GetAllCategories()
        {
            var list = new List<SelectListItem>();

            foreach (var item in _categoryRepo.GetAll())
            {
                list.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }
            return list;
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
                    Value = item.Id.ToString()
                });
            }

            model.Categories = list;

            return View("~/Views/Admin/Categories/Edit.cshtml", model);
        }
    }
}
