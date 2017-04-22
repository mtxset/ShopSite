using System.Collections.Generic;

namespace ShopSite.ProductAttributes.Models
{
    //TODO Delete this class when will finish attribute block
    public class ProductAttributeGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<ProductAttribute> Attributes { get; set; } = new List<ProductAttribute>();
    }
}
