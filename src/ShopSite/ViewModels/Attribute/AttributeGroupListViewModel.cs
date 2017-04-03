using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopSite.ViewModels.Attribute
{
    public class AttributeGroupListViewModel
    {
        public IEnumerable<Models.AttributeGroup> AttributeGroups { get; set; }

        public Models.AttributeGroup AttributeGroup { get; set; }
    }
}
