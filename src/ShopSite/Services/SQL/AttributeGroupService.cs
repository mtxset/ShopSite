using System;
using System.Collections.Generic;
using System.Linq;
using ShopSite.Models;
using ShopSite.Data;

namespace ShopSite.Services.SQL
{
    public class AttributeGroupService : IProductAttributeGroupService
    {
        private ShopSiteDbContext _context;

        public AttributeGroupService(ShopSiteDbContext context)
        {
            _context = context;
        }

        public int Commit()
        {
            return _context.SaveChanges();
        }

        public void Create(ProductAttributeGroup attributeGroup)
        {
            _context.Add(attributeGroup);
        }

        public ProductAttributeGroup Get(int id)
        {
            return _context.AttributeGroupDbContext.FirstOrDefault(r => r.Id == id);
        }

        public IList<ProductAttributeGroup> GetAll()
        {
            return _context.AttributeGroupDbContext.ToList();
        }

        public IQueryable<ProductAttributeGroup> GetListByIds(IList<int> ids)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductAttributeGroup attributeGroup)
        {
            _context.Remove(attributeGroup);
        }

        public void Update(ProductAttributeGroup category)
        {
            throw new NotImplementedException();
        }
    }
}
