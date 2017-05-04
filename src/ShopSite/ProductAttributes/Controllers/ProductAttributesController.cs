using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopSite.Data;
using Microsoft.AspNetCore.Authorization;
using ShopSite.ProductAttibutes.Services;
using System.IO;
using ShopSite.Data.Repository;
using ShopSite.ProductAttributes.Models;
using ShopSite.Services;

namespace ShopSite.ProductAttributes.Controllers
{
    [Authorize(Roles = "admin")]
    public class ProductAttributesController : Controller
    {
        private IRepository<ProductAttribute> _PARepo;
        private IProductAttributeComplexTypeDefinitionsService _PAComplexTDRepo;
        private ICategoryService _PACat;
        private string RootPath = "~/ProductAttributes/Views/ProductAttributes/";

        public ProductAttributesController(IRepository<ProductAttribute> PARepo, IProductAttributeComplexTypeDefinitionsService PAComplexTDRepo,
            ICategoryService PACat)
        {
            _PARepo = PARepo;
            _PAComplexTDRepo = PAComplexTDRepo;
            _PACat = PACat;
        }

        public async Task<IActionResult> Index()
        {
            var qResult = await _PARepo.Table
                .Include(p => p.Category)
                .Include(p => p.ProductAttributeComplexTypeDefinition)
                .ToListAsync();

            // TODO: Json format
            //var res = JsonConvert.SerializeObject(qResult, Formatting.Indented);
            //return Content(res);
            return View(Path.Combine(RootPath, "Index.cshtml"), qResult);
        }

        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_PACat.GetAll(), "Id", "Name");
            ViewData["ProductAttributeComplexTypeDefinitionId"] = new SelectList(_PAComplexTDRepo.GetAllParents(), "Id", "Name");
            ViewData["AttrType"] = new SelectList(Enum.GetNames(typeof(ProductAttribute.AttrType)));

            return View(Path.Combine(RootPath, "Create.cshtml"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProductAttribute productAttribute)
        {

            if (ModelState.IsValid)
            {
                _PARepo.Insert(productAttribute);
                return RedirectToAction("Index");
            }

            return View(Path.Combine(RootPath, "Create.cshtml"));
        }

        public IActionResult Delete(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var productAttribute = _PARepo.GetById(id.Value);
            if (productAttribute == null)
            {
                return NotFound();
            }

            _PARepo.Delete(productAttribute);

            return RedirectToAction("Index");
        }

        public IActionResult Edit(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var productAttribute = _PARepo.GetById(id.Value);
            if (productAttribute == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_PACat.GetAll(), "Id", "Name");
            ViewData["ProductAttributeComplexTypeDefinitionId"] = new SelectList(_PAComplexTDRepo.GetAllParents(), "Id", "Name");
            ViewData["AttrType"] = new SelectList(Enum.GetNames(typeof(ProductAttribute.AttrType)));

            return View(Path.Combine(RootPath, "Edit.cshtml"), productAttribute);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProductAttribute productAttribute)
        {
            if (id != productAttribute.Id) return NotFound();


            if (ModelState.IsValid)
            {
                try
                {
                    _PARepo.DirtyUpdate(productAttribute);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductAttributeExists(productAttribute.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            ViewData["CategoryId"] = new SelectList(_PACat.GetAll(), "Id", "Name");
            ViewData["ProductAttributeComplexTypeDefinitionId"] = new SelectList(_PAComplexTDRepo.GetAllParents(), "Id", "Name");
            ViewData["AttrType"] = new SelectList(Enum.GetNames(typeof(ProductAttribute.AttrType)));

            return View(Path.Combine(RootPath, "Edit.cshtml"), productAttribute);
        }

        private bool ProductAttributeExists(int id)
        {
            //TODO: rewrite
            //return _context.ProductAttributes.Any(e => e.Id == id);
            return true;
        }
    }
}
