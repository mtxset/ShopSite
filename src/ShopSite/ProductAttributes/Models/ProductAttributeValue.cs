using ShopSite.Models;

namespace ShopSite.ProductAttributes.Models
{
    public class ProductAttributeValue
    {
        public int Id { get; set; }

        public int AttributeId { get; set; }
        public int ProductId { get; set; }

        public string Value { get; set; }

        public virtual ProductAttribute Attribute { get; set; }

        public Product Product { get; set; }
    }
}
