using ShopSite.Models;
using ShopSite.ProductAttributes.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopSite.Services
{
    public interface IProductAttributeGroupService
    {
        IList<ProductAttributeGroup> GetAll();
        IQueryable<ProductAttributeGroup> GetListByIds(IList<int> ids);

        ProductAttributeGroup Get(int id);

        int Commit();

        void Create(ProductAttributeGroup attributeGroup);
        void Update(ProductAttributeGroup attributeGroup);
        void Remove(ProductAttributeGroup attributeGroup);
    }
}
