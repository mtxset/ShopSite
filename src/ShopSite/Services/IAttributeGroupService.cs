using ShopSite.Models;
using System.Collections.Generic;
using System.Linq;

namespace ShopSite.Services
{
    public interface IAttributeGroupService
    {
        IList<AttributeGroup> GetAll();
        IQueryable<AttributeGroup> GetListByIds(IList<int> ids);

        AttributeGroup Get(int id);

        int Commit();

        void Create(AttributeGroup attributeGroup);
        void Update(AttributeGroup attributeGroup);
        void Remove(AttributeGroup attributeGroup);
    }
}
