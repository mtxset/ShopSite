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
        //remove some later
        private readonly ShopSiteDbContext _context;

        public ProductAttributeComplexTypeDefinitionsController(ShopSiteDbContext context,
            IProductAttributeComplexTypeDefinitionsService PAComplexTDRepo)
        {
            _PAComplexTDRepo = PAComplexTDRepo;
            // TODO: remove _context
            _context = context;
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
            
            var productAttributeComplexTypeDefinition = _PAComplexTDRepo.GetById(id.Value);
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
        public async Task<IActionResult> Create([Bind("Id,Name,ParentId")] ProductAttributeComplexTypeDefinition productAttributeComplexTypeDefinition)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productAttributeComplexTypeDefinition);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["ParentId"] = new SelectList(_context.ProductAttributeComplexTypeDefinitions, "Id", "Name", productAttributeComplexTypeDefinition.ParentId);
            return View(productAttributeComplexTypeDefinition);
        }

        // GET: ProductAttributeComplexTypeDefinitions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttributeComplexTypeDefinition = await _context.ProductAttributeComplexTypeDefinitions.SingleOrDefaultAsync(m => m.Id == id);
            if (productAttributeComplexTypeDefinition == null)
            {
                return NotFound();
            }
            ViewData["ParentId"] = new SelectList(_context.ProductAttributeComplexTypeDefinitions, "Id", "Name", productAttributeComplexTypeDefinition.ParentId);
            return View(productAttributeComplexTypeDefinition);
        }

        // POST: ProductAttributeComplexTypeDefinitions/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,ParentId")] ProductAttributeComplexTypeDefinition productAttributeComplexTypeDefinition)
        {
            if (id != productAttributeComplexTypeDefinition.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productAttributeComplexTypeDefinition);
                    await _context.SaveChangesAsync();
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
            ViewData["ParentId"] = new SelectList(_context.ProductAttributeComplexTypeDefinitions, "Id", "Name", productAttributeComplexTypeDefinition.ParentId);
            return View(productAttributeComplexTypeDefinition);
        }

        // GET: ProductAttributeComplexTypeDefinitions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productAttributeComplexTypeDefinition = await _context.ProductAttributeComplexTypeDefinitions
                .Include(p => p.Parent)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (productAttributeComplexTypeDefinition == null)
            {
                return NotFound();
            }

            return View(productAttributeComplexTypeDefinition);
        }

        // POST: ProductAttributeComplexTypeDefinitions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productAttributeComplexTypeDefinition = await _context.ProductAttributeComplexTypeDefinitions.SingleOrDefaultAsync(m => m.Id == id);
            _context.ProductAttributeComplexTypeDefinitions.Remove(productAttributeComplexTypeDefinition);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductAttributeComplexTypeDefinitionExists(int id)
        {
            return _context.ProductAttributeComplexTypeDefinitions.Any(e => e.Id == id);
        }
    }
}
