using ShopSite.ProductAttributes.Models;
using System.Collections.Generic;

namespace ShopSite.ViewModels.Attribute
{
    public class AttributeGroupListViewModel
    {
        public IEnumerable<ProductAttributeGroup> AttributeGroups { get; set; }

        public ProductAttributeGroup AttributeGroup { get; set; }
    }
}
