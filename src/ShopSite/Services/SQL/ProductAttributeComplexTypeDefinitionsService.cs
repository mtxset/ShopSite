using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopSite.Models;
using ShopSite.Data;
using ShopSite.ProductAttributes.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopSite.Services.SQL
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
            var IQueryableVar = _context.ProductAttributeComplexTypeDefinition.Include(p => p.Parent);
            return IQueryableVar;
        }
    }
}
