using System;
using System.Collections.Generic;
using ShopSite.Data;
using ShopSite.Models;


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
            throw new NotImplementedException();
        }

        public IList<ProductAttribute> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductAttribute productAttribute)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductAttribute productAttribute)
        {
            throw new NotImplementedException();
        }
    }
}
