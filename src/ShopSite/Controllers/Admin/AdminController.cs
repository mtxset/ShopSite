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
using ShopSite.ViewModels.Attribute;

namespace ShopSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ICategoryService _categoryRepo;
        private IProductService _productRepo;
        private IProductAttributeGroupService _attributeGroupRepo;
        private IProductAttributeService _attributeRepo;

        public AdminController(
            ICategoryService categoryRepo, 
            IProductService productRepo, 
            IProductAttributeGroupService attributeGroupRepo,
            IProductAttributeService attributeRepo)
        {
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _attributeGroupRepo = attributeGroupRepo;
            _attributeRepo = attributeRepo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Attributes()
        {
            var model = new AttributeListViewModel
            {
                ProductAttributes = _attributeRepo.GetAll()
            };

            return View("~/Views/Admin/Attributes/Attributes.cshtml", model);
        }

        public ViewResult AttributeGroups()
        {
            var model = new AttributeGroupListViewModel()
            {
                AttributeGroups = _attributeGroupRepo.GetAll()
            };

            return View("~/Views/Admin/Attributes/AttributeGroups.cshtml", model);
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
        public IActionResult AttributeCreate()
        {
            var list = new List<SelectListItem>();

            foreach (var item in _attributeGroupRepo.GetAll())
            {
                list.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            var model = new AttributeEdit
            {
                Groups = list
            };

            return View("~/Views/Admin/Attributes/AttributeCreate.cshtml", model);
        }

        [HttpGet]
        public IActionResult AttributeGroupCreate()
        {
            return View("~/Views/Admin/Attributes/AttributeGroupCreate.cshtml");
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

        public IActionResult AttributeGroupRemove(int id)
        {
            var attributeGroup = _attributeGroupRepo.Get(id);

            _attributeGroupRepo.Remove(attributeGroup);

            _attributeGroupRepo.Commit();

            return RedirectToAction("Index");
        }

        public IActionResult ProductRemove(int id)
        {
            var product = _productRepo.Get(id);

            _productRepo.Remove(product);
            _productRepo.Commit();

            return RedirectToAction("Index");
        }

        public IActionResult AttributeRemove(int id)
        {
            var attribute = _attributeRepo.Get(id);

            _attributeRepo.Remove(attribute);
            _attributeRepo.Commit();

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
        public IActionResult AttributeGroupCreate(AttributeGroupEdit model)
        {
            if (!ModelState.IsValid)
                return View("~/Views/Admin/Attributes/AttributeGroupCreate.cshtml");

            var attributeGroup = new ProductAttributeGroup()
            {
                Name = model.Name
            };


            _attributeGroupRepo.Create(attributeGroup);
            _attributeGroupRepo.Commit();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult AttributeCreate(AttributeEdit model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("AttributeCreate");

            var attribute = new ProductAttribute
            {
                GroupId = model.GroupId,
                Name = model.Name
            };

            _attributeRepo.Create(attribute);
            _attributeRepo.Commit();

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

        [HttpGet]
        IActionResult AttributeGroupEdit(int id, AttributeGroupEdit model)
        {
            var attributeGroup = _attributeGroupRepo.Get(id);

            if (ModelState.IsValid && attributeGroup != null)
            {
                attributeGroup.Name = model.Name;

                _attributeGroupRepo.Update(attributeGroup);
                _attributeGroupRepo.Commit();

                return RedirectToAction("Index");
            }
            return View("~/Views/Admin/Attributes/AttributeGroupEdit.cshtml");
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

                return RedirectToAction("Index");
            }

            return View("~/Views/Admin/Categories/Edit.cshtml");
        }

        [HttpPost]
        public IActionResult ProductEdit(int id, ProductEdit model)
        {
            var product = _productRepo.Get(id);

            if (ModelState.IsValid && product != null)
            {
                product = model.Product;

                _productRepo.Update(product);
                _productRepo.Commit();

                return RedirectToAction("Index");
            }

            return View("~/Views/Admin/Products/Edit.cshtml");
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
                    selectItem.Selected = string.Equals(selectItem.Text, item.Name);
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
                    Value = item.ParentId.ToString()
                });
            }

            model.Categories = list;

            return View("~/Views/Admin/Categories/Edit.cshtml", model);
        }
    }
}
