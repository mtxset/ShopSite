using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopSite.ViewModels.Attribute
{
    public class AttributeGroupListViewModel
    {
        public IEnumerable<Models.ProductAttributeGroup> AttributeGroups { get; set; }

        public Models.ProductAttributeGroup AttributeGroup { get; set; }
    }
}
