﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ShopSite.Data;
using ShopSite.Models;

namespace ShopSite.Services.SQL
{
    public class ProductService : IProductService
    {
        private ShopSiteDbContext _context;

        public ProductService(ShopSiteDbContext context)
        {
            _context = context;
        }

        public IList<Product> GetAll()
        {
            return _context.ProductDbContext.ToList();
        }

        public Product Get(int id)
        {
            return _context.ProductDbContext.FirstOrDefault(r => r.Id == id);
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
            throw new NotImplementedException();
        }

        public void Remove(Product product)
        {
            _context.Remove(product);
        }
    }
}