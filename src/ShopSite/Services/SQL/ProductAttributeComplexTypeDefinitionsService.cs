using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopSite.Models;
using ShopSite.Data;

namespace ShopSite.Services.SQL
{
    public class ProductAttributeComplexTypeDefinitionsService : IProductAttributeComplexTypeDefinitionsService
    {
        private ShopSiteDbContext _context;

        public ProductAttributeComplexTypeDefinitionsService(ShopSiteDbContext context)
        {
            _context = context;
        }
    }
}
