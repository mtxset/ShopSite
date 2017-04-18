using System;
using System.Collections.Generic;
using System.Linq;
using ShopSite.Models;
using ShopSite.Data;
using ShopSite.ProductAttributes.Models;

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
            throw new NotImplementedException();
        }

        public void Create(ProductAttributeGroup attributeGroup)
        {
            throw new NotImplementedException();
        }

        public ProductAttributeGroup Get(int id)
        {
            throw new NotImplementedException();
        }

        public IList<ProductAttributeGroup> GetAll()
        {
            throw new NotImplementedException();
        }

        public IQueryable<ProductAttributeGroup> GetListByIds(IList<int> ids)
        {
            throw new NotImplementedException();
        }

        public void Remove(ProductAttributeGroup attributeGroup)
        {
            throw new NotImplementedException();
        }

        public void Update(ProductAttributeGroup attributeGroup)
        {
            throw new NotImplementedException();
        }
    }
}
