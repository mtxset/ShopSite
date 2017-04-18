using ShopSite.ProductAttributes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.Services
{
    public interface IProductAttributeComplexTypeDefinitionsService
    {
        IQueryable<ProductAttributeComplexTypeDefinition> GetAll();
    }
}
