using System;
using System.Collections.Generic;
using System.Linq;
using ShopSite.Data;
using ShopSite.Models;
using Microsoft.EntityFrameworkCore;

namespace ShopSite.Services.SQL
{
    public class AttributeService : IProductAttributeService
    {
        private ShopSiteDbContext _context;

        public AttributeService(ShopSiteDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Create(ProductAttribute productAttribute)
        {
            _context.Add(productAttribute);
        }

        public ProductAttribute Get(int id)
        {
            return _context.AttributeDbContext
                .FirstOrDefault(r => r.Id == id);
        }

        public IList<ProductAttribute> GetAll()
        {
            return _context.AttributeDbContext.Include(x => x.Group).ToList();
        }

        public void Remove(ProductAttribute productAttribute)
        {
            _context.Remove(productAttribute);
        }

        public void Update(ProductAttribute productAttribute)
        {
            _context.Update(productAttribute);
        }
    }
}
