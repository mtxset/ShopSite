using System.Collections.Generic;
using System.Linq;
using ShopSite.Models;

namespace ShopSite.Services
{
    public interface IProductService
    {
        IList<Product> GetAll();
        IList<Product> GetByListOfIds(List<int> ids);

        IQueryable<Product> GetByCategory(int id);

        Product GetWithCategories(int id);
        Product Get(int id);

        int Commit();

        IQueryable QueryProduct();
        IQueryable<Product> QueryableProduct();

        void Create(Product product);
        void Update(Product product);
        void Remove(Product product);
    }
}
