using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopSite.Data;
using ShopSite.ProductAttributes.Models;
using Microsoft.AspNetCore.Authorization;
using ShopSite.ProductAttibutes.Services;
using Newtonsoft.Json;

namespace ShopSite.Models
{
    [Authorize(Roles = "admin")]
    public class ProductAttributeComplexTypeDefinitionsController : Controller
    {
        private IProductAttributeComplexTypeDefinitionsService _PAComplexTDRepo;
        
        public ProductAttributeComplexTypeDefinitionsController(IProductAttributeComplexTypeDefinitionsService PAComplexTDRepo)
        {
            _PAComplexTDRepo = PAComplexTDRepo;
        }

        // GET: ProductAttributeComplexTypeDefinitions
        public async Task<IActionResult> Index()
        {
            var qResult = _PAComplexTDRepo.GetAll();

            // TODO: Json format
            //var res = JsonConvert.SerializeObject(qResult, Formatting.Indented);
            //return Content(res);
            return View("~/ProductAttributes/Views/ProductAttributeComplexTypeDefinitions/Index.cshtml", await qResult.ToListAsync());
        }

        // GET: ProductAttributeComplexTypeDefinitions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
                return NotFound();
            
            var productAttributeComplexTypeDefinition = await _PAComplexTDRepo.GetById(id.Value);
            if (productAttributeComplexTypeDefinition == null)
            {
                return NotFound();
            }

            return View("~/ProductAttributes/Views/ProductAttributeComplexTypeDefinitions/Details.cshtml", productAttributeComplexTypeDefinition);
        }

        // GET: ProductAttributeComplexTypeDefinitions/Create
        public IActionResult Create()
        {
            ViewData["ParentId"] = new SelectList(_PAComplexTDRepo.GetAll().ToList(), "Id", "Name");
            return View("~/ProductAttributes/Views/ProductAttributeComplexTypeDefinitions/Create.cshtml");
        }

        // POST: ProductAttributeComplexTypeDefinitions/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductAttributeComplexTypeDefinition productAttributeComplexTypeDefinition)
        {

            if (ModelState.IsValid)
            {
                var model = new ProductAttributeComplexTypeDefinition()
                {
                    Name = productAttributeComplexTypeDefinition.Name,
                    ParentId = productAttributeComplexTypeDefinition.ParentId
                };

                await _PAComplexTDRepo.AddNewItem(model);
                return RedirectToAction("Index");
            }
            ViewData["ParentId"] = new SelectList(_PAComplexTDRepo.GetAll().ToList(), "Id", "Name", productAttributeComplexTypeDefinition.ParentId);
            return View("~/ProductAttributes/Views/ProductAttributeComplexTypeDefinitions/Create.cshtml", productAttributeComplexTypeDefinition);
        }

        // GET: ProductAttributeComplexTypeDefinitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var productAttributeComplexTypeDefinition = await _PAComplexTDRepo.GetById(id.Value);
            if (productAttributeComplexTypeDefinition == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_PAComplexTDRepo.GetAll().ToList(), "Id", "Name", productAttributeComplexTypeDefinition.ParentId);
            return View("~/ProductAttributes/Views/ProductAttributeComplexTypeDefinitions/Edit.cshtml", productAttributeComplexTypeDefinition);
        }

        // POST: ProductAttributeComplexTypeDefinitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductAttributeComplexTypeDefinition productAttributeComplexTypeDefinition)
        {
            if (id != productAttributeComplexTypeDefinition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await _PAComplexTDRepo.UpdateObj(productAttributeComplexTypeDefinition);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductAttributeComplexTypeDefinitionExists(productAttributeComplexTypeDefinition.Id))
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
            ViewData["ParentId"] = new SelectList(_PAComplexTDRepo.GetAll().ToList(), "Id", "Name", productAttributeComplexTypeDefinition.ParentId);
            return View(productAttributeComplexTypeDefinition);
        }

        // GET: ProductAttributeComplexTypeDefinitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return NotFound();

            var productAttributeComplexTypeDefinition = await _PAComplexTDRepo.GetById(id.Value);
            if (productAttributeComplexTypeDefinition == null)
            {
                return NotFound();
            }

            return View("~/ProductAttributes/Views/ProductAttributeComplexTypeDefinitions/Delete.cshtml");
        }

        // POST: ProductAttributeComplexTypeDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _PAComplexTDRepo.RemoveById(id);
            return RedirectToAction("Index");
        }

        private bool ProductAttributeComplexTypeDefinitionExists(int id)
        {
            //TODO: rewrite
            //return _context.ProductAttributeComplexTypeDefinitions.Any(e => e.Id == id);
            return true;

        }
    }
}
