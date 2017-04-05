namespace ShopSite.Models
{
    public class ProductAttribute
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }

        public AttrType AtributeType { get; set; }
        public int ProductAttributeCompexTypeDefinitionId { get; set; }
        public ProductAttributeCompexTypeDefinition ProductAttributeCompexTypeDefinition { get; set; }

        public enum AttrType
        {
            TypeInteger,
            TypeDecimal,
            TypeString,
            TypeData,
            TypeOther
        }
    }
}
