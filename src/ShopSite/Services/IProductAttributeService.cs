using System.Collections.Generic;
using ShopSite.Models;
using ShopSite.ProductAttributes.Models;

namespace ShopSite.Services
{
    public interface IProductAttributeService
    {
        IList<ProductAttribute> GetAll();

        int Commit();

        ProductAttribute Get(int id);

        void Create(ProductAttribute product);
        void Update(ProductAttribute product);
        void Remove(ProductAttribute product);
    }
}