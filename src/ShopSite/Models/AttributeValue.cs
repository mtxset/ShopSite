namespace ShopSite.Models
{
    public class AttributeValue
    {
        public int Id { get; set; }

        public int AttributeId { get; set; }
        public int ProductId { get; set; }

        public string Value { get; set; }

        public virtual Attribute Attribute { get; set; }

        public Product Product { get; set; }
    }
}
