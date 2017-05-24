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
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.AspNetCore.Hosting;
using System.Threading.Tasks;
using ShopSite.ProductOptions.Models;
using Newtonsoft.Json;
using ShopSite.ProductOptions.ViewModels;
using ShopSite.ProductAttributes.Models;
using ShopSite.ProductAttributes.ViewModels;
using static ShopSite.ProductAttributes.Models.ProductAttribute;
using ShopSite.ProductAttibutes.Services;
using System;

namespace ShopSite.Controllers
{
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private ICategoryService _categoryRepo;
        private IProductService _productRepo;
        private IRepository<ProductOption> _productOptionsRepo;
        private IRepository<ProductOptionValue> _productOptionValuesRepo;
        private IRepository<ProductCategory> _productCategoryRepo;
        private IRepository<ProductAttribute> _PARepoProductAttribute;

        private IRepository<ProductAttributeDate> _PARepoProductAttributeDate;
        private IRepository<ProductAttributeDec> _PARepoProductAttributeDec;
        private IRepository<ProductAttributeInt> _PARepoProductAttributeInt;
        private IRepository<ProductAttributeString> _PARepoProductAttributeString;
        private IRepository<ProductAttributeCompexType> _PARepoProductAttributeCompT;

        private IProductAttributeComplexTypeDefinitionsService _PAComplexTDRepo;

        private int productsPageSize;
        private IHostingEnvironment _env;

        public AdminController(
            ICategoryService categoryRepo,
            IProductService productRepo,
            IRepository<ProductCategory> productCategoryRepo,
            IConfiguration _config,
            IHostingEnvironment env,
            IRepository<ProductOptionValue> productOptionValuesRepo,
            IRepository<ProductOption> productOptionsRepo,
            IRepository<ProductAttribute> PARepoProductAttribute,
            IRepository<ProductAttributeDate> PARepoProductAttributeDate,
            IRepository<ProductAttributeDec> PARepoProductAttributeDec,
            IRepository<ProductAttributeInt> PARepoProductAttributeInt,
            IRepository<ProductAttributeString> PARepoProductAttributeString,
            IRepository<ProductAttributeCompexType> PARepoProductAttributeCompT,
            IProductAttributeComplexTypeDefinitionsService PAComplexTDRepo)
        {
            _productOptionsRepo = productOptionsRepo;
            _productOptionValuesRepo = productOptionValuesRepo;
            _categoryRepo = categoryRepo;
            _productRepo = productRepo;
            _productCategoryRepo = productCategoryRepo;
            productsPageSize = _config.GetValue<int>("ProductsPageSize");
            _env = env;

            _PARepoProductAttribute = PARepoProductAttribute;
            _PARepoProductAttributeDate = PARepoProductAttributeDate;
            _PARepoProductAttributeDec = PARepoProductAttributeDec;
            _PARepoProductAttributeInt = PARepoProductAttributeInt;
            _PARepoProductAttributeString = PARepoProductAttributeString;
            _PARepoProductAttributeCompT = PARepoProductAttributeCompT;
            _PAComplexTDRepo = PAComplexTDRepo;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Products(string currentFilter, string sortOrder, string searchString, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["PriceSortParm"] = sortOrder == "price" ? "price_desc" : "price";
            ViewData["StockSortParm"] = sortOrder == "stock" ? "stock_desc" : "stock";
            ViewData["IsFeaturedParm"] = sortOrder == "isFeatured" ? "isNotFeatured" : "isFeatured";
            ViewData["IsAllowedToOrderParm"] = sortOrder == "isAllowedToOrder" ? "isNotAllowedToOrder" : "isAllowedToOrder";

            var model = new ProductListViewModel();

            if (page.HasValue)
                model.IndexPage = page.Value;
            else
                model.IndexPage = 0;

            if (searchString != null)
                model.IndexPage = 0;
            else
                searchString = currentFilter;

            ViewData["CurrentFilter"] = searchString;

            var q = _productRepo.QueryProduct().Cast<Product>();

            switch (sortOrder)
            {
                case "price":
                    q = q.OrderBy(x => x.Price);
                    break;
                case "price_desc":
                    q = q.OrderByDescending(x => x.Price);
                    break;
                case "stock":
                    q = q.OrderBy(x => x.StockQuantity);
                    break;
                case "stock_desc":
                    q = q.OrderByDescending(x => x.StockQuantity);
                    break;

                case "isFeatured":
                    q = q.Where(x => x.IsFeatured);
                    break;
                case "isNotFeatured":
                    q = q.Where(x => x.IsFeatured == false);
                    break;

                case "isAllowedToOrder":
                    q = q.Where(x => x.IsAllowedToOrder);
                    break;
                case "isNotAllowedToOrder":
                    q = q.Where(x => x.IsAllowedToOrder == false);
                    break;
            }

            if (!string.IsNullOrEmpty(searchString))
                q = q.Where(x => x.Name.Contains(searchString));

            model.Products = new PagedList<Product>(q.ToList(), model.IndexPage, productsPageSize);

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
            var q = _productOptionsRepo.Table.ToList();

            var options = q.Select(x => new ProductOptionVm()
            {
                Id = x.Id,
                Name = x.Name

            }).ToList();

            var model = new ProductEdit
            {
                Categories = GetAllCategories(),
                Options = options
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
        public async Task<IActionResult> ProductCreate(ProductEdit model)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("ProductCreate");

            var product = model.Product;

            if (model.File != null)
            {
                if (!string.IsNullOrEmpty(model.File.FileName))
                {
                    var filePath = Path.Combine(_env.ContentRootPath, "wwwroot\\images", model.File.FileName);
                    if (model.File.Length > 0)
                        using (var stream = new FileStream(filePath, FileMode.Create))
                        {
                            await model.File.CopyToAsync(stream);
                            product.ImageUrl = Path.Combine("/images/", model.File.FileName);
                        }
                }
            }
            else
                product.ImageUrl = Path.Combine("/images/", "cheese.jpg");

            foreach (var item in model.Options)
            {
                product.AddOptionValue(new ProductOptionValue
                {
                    OptionId = item.Id,
                    Value = JsonConvert.SerializeObject(item.Values)
                });
            }

            // TODO: remove; uncomment if on creating you need to select few categories
            //var categories = _categoryRepo.GetAll();

            //var categoryIds = categories.Select(item => item.Id).ToList();

            var selectedCategoryIds = new List<int>();
            selectedCategoryIds.Add(model.SelectedCategory);

            /*for (var i = 0; i < model.SelectedCategories.Count; i++)
            {
                if (model.SelectedCategories[i])
                {
                    selectedCategoryIds.Add(categoryIds[i]);
                }
            }*/

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

            return RedirectToAction("Products");
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

                // TODO: fix
                if (model.EditImageUrl && !string.IsNullOrEmpty(model.Product.ImageUrl))
                    product.ImageUrl = Path.Combine("/images/", model.Product.ImageUrl);

                //var categories = _categoryRepo.GetAll();
                //var selectedCategoryIds = new List<int>();
                //var categoryIds = categories.Select(item => item.Id).ToList();

                //for (var i = 0; i < model.SelectedCategories.Count; i++)
                //{
                //    if (model.SelectedCategories[i])
                //    {
                //        selectedCategoryIds.Add(categoryIds[i]);
                //    }
                //}

                //foreach (var item in selectedCategoryIds)
                //{
                //    if (product.Categories.Any(x => x.CategoryId == item))
                //    {
                //        continue;
                //    }

                //    var productCategory = new ProductCategory
                //    {
                //        CategoryId = item
                //    };
                //    product.AddCategory(productCategory);
                //}

                //List<ProductCategory> deletedProductCategories = product.Categories
                //    .Where(x => !selectedCategoryIds.Contains(x.CategoryId)).ToList();

                //foreach (var item in deletedProductCategories)
                //{
                //    item.Product = null;
                //    product.Categories.Remove(item);
                //    _productCategoryRepo.Delete(item);
                //}

                _productRepo.Update(product);
                _productRepo.Commit();

                bool FlagCreation;

                foreach (var ProductAttribute in model.ProductAttributes)
                    switch (ProductAttribute.AttrType)
                    {
                        case AttrType.TypeData:
                            var t = _PARepoProductAttributeDate.Table.SingleOrDefault(m => m.ProductId == id) ?? null;
                            FlagCreation = t == null ? true : false;

                            if (FlagCreation) t = new ProductAttributeDate();

                            DateTime ValueDT;
                            if (!DateTime.TryParse(ProductAttribute.Value, out ValueDT)) break;

                            t.AtributeNameId = ProductAttribute.ProductAttributeId;
                            t.ProductId = ProductAttribute.ProductId;
                            t.Value = ValueDT;

                            if (FlagCreation) _PARepoProductAttributeDate.Insert(t);
                            else _PARepoProductAttributeDate.Update(t);
                            break;
                        case AttrType.TypeDecimal:
                            var t1 = _PARepoProductAttributeDec.Table.SingleOrDefault(m => m.ProductId == id) ?? null;
                            FlagCreation = t1 == null ? true : false;

                            if (FlagCreation) t1 = new ProductAttributeDec();

                            Decimal ValueDec;
                            if (!Decimal.TryParse(ProductAttribute.Value, out ValueDec)) break;

                            t1.AtributeNameId = ProductAttribute.ProductAttributeId;
                            t1.ProductId = ProductAttribute.ProductId;
                            t1.Value = ValueDec;

                            if (FlagCreation) _PARepoProductAttributeDec.Insert(t1);
                            else _PARepoProductAttributeDec.Update(t1);
                            break;
                        case AttrType.TypeInteger:
                            var t2 = _PARepoProductAttributeInt.Table.SingleOrDefault(m => m.ProductId == id && m.AtributeNameId == ProductAttribute.ProductAttributeId) ?? null;
                            FlagCreation = t2 == null ? true : false;

                            if (FlagCreation) t2 = new ProductAttributeInt();

                            int ValueInt;
                            if (!int.TryParse(ProductAttribute.Value, out ValueInt)) break;

                            t2.AtributeNameId = ProductAttribute.ProductAttributeId;
                            t2.ProductId = ProductAttribute.ProductId;
                            t2.Value = ValueInt;

                            if (FlagCreation) _PARepoProductAttributeInt.Insert(t2);
                            else _PARepoProductAttributeInt.Update(t2);

                            break;
                        case AttrType.TypeString:
                            var t3 = _PARepoProductAttributeString.Table.SingleOrDefault(m => m.ProductId == id && m.AtributeNameId == ProductAttribute.ProductAttributeId) ?? null;

                            FlagCreation = t3 == null ? true : false;

                            if (FlagCreation) t3 = new ProductAttributeString();

                            t3.AtributeNameId = ProductAttribute.ProductAttributeId;
                            t3.ProductId = ProductAttribute.ProductId;
                            t3.Value = ProductAttribute.Value;

                            if (FlagCreation) _PARepoProductAttributeString.Insert(t3);
                            else _PARepoProductAttributeString.Update(t3);
                            break;
                    }

                foreach (var ProductAttributeCT in model.ProductAttributesCompT)
                {
                    var t4 = _PARepoProductAttributeCompT.Table.SingleOrDefault(m => m.ProductId == id && m.AtributeNameId == ProductAttributeCT.ProductAttributeId) ?? null;

                    FlagCreation = t4 == null ? true : false;
                    if (FlagCreation) t4 = new ProductAttributeCompexType();

                    if (ProductAttributeCT.ValueId != null)
                    {
                        t4.AtributeNameId = ProductAttributeCT.ProductAttributeId;
                        t4.ProductId = ProductAttributeCT.ProductId;
                        t4.ValueId = ProductAttributeCT.ValueId;

                        if (FlagCreation) _PARepoProductAttributeCompT.Insert(t4);
                        else _PARepoProductAttributeCompT.Update(t4);
                    }
                }

                return RedirectToAction("Products");
            }

            return RedirectToAction("Index");

        }

        // TODO: Incorporate Option Value edit and image download
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

            if (productCategoryIds.Count == 0)
                return NotFound(); // there should be no products without category

            var Category = _categoryRepo.GetCategory(productCategoryIds[0]);

            if (string.IsNullOrEmpty(Category.Name))
                return NotFound();

            model.Category = Category;

            //added product attribute parameters
            //var Category = product.Categories[0];
            var ListOfAttributes = _PARepoProductAttribute.Table.Where(m => m.CategoryId == Category.Id);
            foreach (var Attribute in ListOfAttributes)
            {
                var modelProductAttribute = new ProductAttributeVm();
                modelProductAttribute.ProductAttributeId = Attribute.Id;
                modelProductAttribute.ProductId = id;
                modelProductAttribute.ProductAttributeName = Attribute.Name;
                modelProductAttribute.AttrType = Attribute.AtributeType;

                var modelProductAttributeCompT = new ProductAttributeCompTVm();
                modelProductAttributeCompT.ProductAttributeId = Attribute.Id;
                modelProductAttributeCompT.ProductId = id;
                modelProductAttributeCompT.ProductAttributeName = Attribute.Name;

                switch (Attribute.AtributeType)
                {
                    case AttrType.TypeData:
                        var t = _PARepoProductAttributeDate.Table.SingleOrDefault(m => m.ProductId == id) ?? null;
                        if (t != null) modelProductAttribute.Value = t.Value.ToString();
                        model.ProductAttributes.Add(modelProductAttribute);
                        break;
                    case AttrType.TypeDecimal:
                        var t1 = _PARepoProductAttributeDec.Table.SingleOrDefault(m => m.ProductId == id) ?? null;
                        if (t1 != null) modelProductAttribute.Value = t1.Value.ToString();
                        model.ProductAttributes.Add(modelProductAttribute);
                        break;
                    case AttrType.TypeInteger:
                        var t2 = _PARepoProductAttributeInt.Table.SingleOrDefault(m => m.ProductId == id) ?? null;
                        if (t2 != null) modelProductAttribute.Value = t2.Value.ToString();
                        model.ProductAttributes.Add(modelProductAttribute);
                        break;
                    case AttrType.TypeString:
                        var t3 = _PARepoProductAttributeString.Table.SingleOrDefault(m => m.ProductId == id) ?? null;
                        if (t3 != null) modelProductAttribute.Value = t3.Value.ToString();
                        model.ProductAttributes.Add(modelProductAttribute);
                        break;
                    case AttrType.TypeOther:
                        var t4 = _PARepoProductAttributeCompT.Table.SingleOrDefault(m => m.ProductId == id) ?? null;
                        if (t4 != null)
                        {
                            modelProductAttributeCompT.Value = t4.Value;
                            modelProductAttributeCompT.ValueId = t4.ValueId;
                        }
                        var t5 = _PAComplexTDRepo.GetByParent(Attribute.ProductAttributeComplexTypeDefinitionId);
                        if (t5 != null)
                        {
                            var list = new List<SelectListItem>();

                            foreach (var item in t5.ToList())
                            {
                                list.Add(new SelectListItem()
                                {
                                    Text = item.Name,
                                    Value = item.Id.ToString()
                                });
                            }

                            modelProductAttributeCompT.ProductAttributeComplexTypeDefinition = list;
                        }
                        
                        
                        
                        model.ProductAttributesCompT.Add(modelProductAttributeCompT);
                        break;
                }
            }
            
            return View("~/Views/Admin/Products/Edit.cshtml", model);
        }

        private List<SelectListItem> GetAllOptions()
        {
            var list = new List<SelectListItem>();

            foreach (var item in _productOptionsRepo.Table.ToList())
            {
                list.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.Id.ToString()
                });
            }

            return list;
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
