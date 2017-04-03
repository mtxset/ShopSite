using System.Collections.Generic;

namespace ShopSite.ViewModels.Attribute
{
    public class AttributeListViewModel
    {
        public IEnumerable<Models.ProductAttribute> ProductAttributes { get; set; }

        public Models.ProductAttribute ProductAttribute { get; set; }

        public Models.ProductAttributeGroup AttributeGroup { get; set; }
    }
}
