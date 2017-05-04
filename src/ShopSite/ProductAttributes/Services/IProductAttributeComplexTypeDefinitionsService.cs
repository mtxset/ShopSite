using ShopSite.ProductAttributes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.ProductAttibutes.Services
{
    public interface IProductAttributeComplexTypeDefinitionsService
    {
        IQueryable<ProductAttributeComplexTypeDefinition> GetAll();
        ProductAttributeComplexTypeDefinition GetById(int id);
    }
}
