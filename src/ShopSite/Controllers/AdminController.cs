using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopSite.Models;
using ShopSite.Services;
using ShopSite.ViewModels;
using ShopSite.ViewModels.Account;

namespace ShopSite.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private ICategoryService _categoryData;

        public AdminController(ICategoryService data)
        {
            _categoryData = data;
        }

        public ViewResult Index()
        {
            return View();
        }

        public ViewResult Categories()
        {
            var model = new CategoryListViewModel
            {
                Categories = _categoryData.GetAll()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        //[HttpDelete]
        public IActionResult Remove(int id)
        {
            var category = _categoryData.GetCategory(id);

            _categoryData.Remove(category);
            _categoryData.Commit();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public IActionResult Create(CategoryEditViewModel model)
        {
            if (!User.IsInRole("Admin")) return View();

            if (!ModelState.IsValid)
                return View();

            var category = new Category
            {
                Name = model.Name,
                Description = model.Description
            };

            _categoryData.Create(category);
            _categoryData.Commit();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Edit(int id, CategoryEditViewModel model)
        {
            var category = _categoryData.GetCategory(id);

            if (ModelState.IsValid && category != null)
            {
                category.Name = model.Name;
                category.Description = model.Description;
                //category.ParentId = model.ParentId;

                _categoryData.Commit();

                return RedirectToAction("Index");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var model = _categoryData.GetCategory(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);

            /*
            var model = new TempEdit();

            model.Category = _categoryData.GetCategory(id);

            return View(model);

            
            var model = _categoryData.GetCategory(id);

            if (model == null)
            {
                return RedirectToAction("Index");
            }

            return View(model);
            */
            /*
            var model = new CategoryListViewModel
            {
                Categories = _categoryData.GetAll(),
                Category = _categoryData.GetCategory(id)
            };

            List<SelectListItem> sl = new List<SelectListItem>();

            foreach (var item in model.Categories)
            {
                sl.Add(new SelectListItem()
                {
                    Text = item.Name,
                    Value = item.ParentId.ToString(),
                    Selected = item.Id == model.Category.ParentId
                });
            }

            model.ConvertedCategories = sl;
            return View(model);*/
        }
    }
}
