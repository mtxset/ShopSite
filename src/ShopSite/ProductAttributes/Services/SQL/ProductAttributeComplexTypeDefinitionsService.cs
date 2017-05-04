using System.Linq;
using ShopSite.Data;
using ShopSite.ProductAttributes.Models;
using Microsoft.EntityFrameworkCore;
using ShopSite.ProductAttibutes.Services;

namespace ShopSite.ProductAttributes.Services.SQL
{
    public class ProductAttributeComplexTypeDefinitionsService : IProductAttributeComplexTypeDefinitionsService
    {
        private ShopSiteDbContext _context;

        public ProductAttributeComplexTypeDefinitionsService(ShopSiteDbContext context)
        {
            _context = context;
        }

        public IQueryable<ProductAttributeComplexTypeDefinition> GetAll()
        {
            var IQueryableVar = _context.ProductAttributeComplexTypeDefinitions.Include(p => p.Parent);
            return IQueryableVar;
        }

        public ProductAttributeComplexTypeDefinition GetById(int id)
        {
            var productAttributeComplexTypeDefinition = _context.ProductAttributeComplexTypeDefinitions
                .Include(p => p.Parent)
                .SingleOrDefault(m => m.Id == id);
            return productAttributeComplexTypeDefinition;
        }
    }
}
