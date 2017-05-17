using System.Linq;
using ShopSite.Data;
using ShopSite.ProductAttributes.Models;
using Microsoft.EntityFrameworkCore;
using ShopSite.ProductAttibutes.Services;
using System;
using System.Threading.Tasks;

namespace ShopSite.ProductAttributes.Services.SQL
{
    public class ProductAttributeComplexTypeDefinitionsService : IProductAttributeComplexTypeDefinitionsService
    {
        private ShopSiteDbContext _context;

        public ProductAttributeComplexTypeDefinitionsService(ShopSiteDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddNewItem(ProductAttributeComplexTypeDefinition productAttributeComplexTypeDefinition)
        {
            _context.Add(productAttributeComplexTypeDefinition);
            return await _context.SaveChangesAsync();
        }

        public IQueryable<ProductAttributeComplexTypeDefinition> GetAll()
        {
            var IQueryableVar = _context.ProductAttributeComplexTypeDefinitions.Include(p => p.Parent);
            return IQueryableVar;
        }

        public IQueryable<ProductAttributeComplexTypeDefinition> GetAllParents()
        {
            var IQueryableVar = _context.ProductAttributeComplexTypeDefinitions
                .Include(p => p.Parent).Where(p => p.Parent==null);
            return IQueryableVar;
        }

        public async Task<ProductAttributeComplexTypeDefinition> GetById(int id)
        {
            var productAttributeComplexTypeDefinition = _context.ProductAttributeComplexTypeDefinitions
                .Include(p => p.Parent)
                .SingleOrDefaultAsync(m => m.Id == id);
            return await productAttributeComplexTypeDefinition;
        }

        public IQueryable<ProductAttributeComplexTypeDefinition> GetByParent(int? ParentId)
        {
            var IQueryableVar = _context.ProductAttributeComplexTypeDefinitions
                .Where(p => p.ParentId == ParentId);
            return IQueryableVar;
        }

        public async Task<int> RemoveById(int id)
        {
            var productAttributeComplexTypeDefinition = _context.ProductAttributeComplexTypeDefinitions
                .Include(p => p.Parent)
                .SingleOrDefault(m => m.Id == id);
            _context.ProductAttributeComplexTypeDefinitions.Remove(productAttributeComplexTypeDefinition);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> UpdateObj(ProductAttributeComplexTypeDefinition productAttributeComplexTypeDefinition)
        {
            _context.Update(productAttributeComplexTypeDefinition);
            return await _context.SaveChangesAsync();
        }
    }
}
