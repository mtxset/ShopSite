using System.Collections.Generic;
using ShopSite.ProductAttributes.Models;

namespace ShopSite.ViewModels.Attribute
{
    public class AttributeListViewModel
    {
        public IEnumerable<ProductAttribute> ProductAttributes { get; set; }

        public ProductAttribute ProductAttribute { get; set; }

        public ProductAttributeGroup AttributeGroup { get; set; }
    }
}
