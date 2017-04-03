using System;
using System.Collections.Generic;
using System.Linq;
using ShopSite.Models;
using ShopSite.Data;

namespace ShopSite.Services.SQL
{
    public class AttributeGroupService : IAttributeGroupService
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

        public void Create(AttributeGroup attributeGroup)
        {
            _context.Add(attributeGroup);
        }

        public AttributeGroup Get(int id)
        {
            return _context.AttributeGroupDbContext.FirstOrDefault(r => r.Id == id);
        }

        public IList<AttributeGroup> GetAll()
        {
            return _context.AttributeGroupDbContext.ToList();
        }

        public IQueryable<AttributeGroup> GetListByIds(IList<int> ids)
        {
            throw new NotImplementedException();
        }

        public void Remove(AttributeGroup attributeGroup)
        {
            _context.Remove(attributeGroup);
        }

        public void Update(AttributeGroup category)
        {
            throw new NotImplementedException();
        }
    }
}
