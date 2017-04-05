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
            throw new NotImplementedException();
        }

        public void Create(ProductAttribute product)
        {
            throw new NotImplementedException();
        }

        public ProductAttribute Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProductAttribute> GetAll()
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductAttribute product)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductAttribute product)
        {
            throw new NotImplementedException();
        }
    }
}
