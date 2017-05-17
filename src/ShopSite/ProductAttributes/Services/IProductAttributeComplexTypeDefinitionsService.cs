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
        IQueryable<ProductAttributeComplexTypeDefinition> GetAllParents();
        IQueryable<ProductAttributeComplexTypeDefinition> GetByParent(int? ParentId);
        Task<ProductAttributeComplexTypeDefinition> GetById(int id);
        Task<int> RemoveById(int id);
        Task<int> UpdateObj(ProductAttributeComplexTypeDefinition productAttributeComplexTypeDefinition);
        Task<int> AddNewItem(ProductAttributeComplexTypeDefinition productAttributeComplexTypeDefinition);
    }
}
