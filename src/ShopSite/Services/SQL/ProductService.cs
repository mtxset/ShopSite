using System;
using System.Collections.Generic;
using System.Linq;
using ShopSite.Data;
using ShopSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopSite.Services.SQL
{
    public class ProductService : IProductService
    {
        private ShopSiteDbContext _context;

        public ProductService(ShopSiteDbContext context)
        {
            _context = context;
        }

        public IQueryable QueryProduct()
        {
            return _context.Products;
        }

        public IList<Product> GetAll()
        {
            return _context.Products.ToList();
        }

        public IList<Product> GetByListOfIds(List<int> ids)
        {
            return _context.Products.Where(s => ids.Any(id => id == s.Id)).ToList();
        }

        public Product GetWithCategories(int id)
        {
            return _context.Products
                .Include(x => x.Categories)
                .FirstOrDefault(r => r.Id == id);
        }

        public Product Get(int id)
        {
            return _context.Products.FirstOrDefault(r => r.Id == id);
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Create(Product product)
        {
            _context.Add(product);
        }

        public void Update(Product product)
        {
            _context.Update(product);
        }

        public void Remove(Product product)
        {
            _context.Remove(product);
        }

        public IQueryable<Product> GetByCategory(int id)
        {
            return _context.Products.Where(x => x.Categories.Any(c => c.CategoryId == id));
        }
    }
}
