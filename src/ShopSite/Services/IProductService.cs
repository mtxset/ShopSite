using System.Collections.Generic;
using ShopSite.Models;

namespace ShopSite.Services
{
    public interface IProductService
    {
        IList<Product> GetAll();

        Product Get(int id);

        int Commit();

        void Create(Product product);
        void Update(Product product);
        void Remove(Product product);
    }
}
