using ShopSite.Models;

namespace ShopSite.ProductAttributes.Models
{
    public class ProductAttribute
    {
        public int Id { get; set; }

        public int CategoryId { get; set; }
        /// <summary>
        /// Name of attribute (Vendor, Amount of volume, Country)
        /// </summary>
        public string Name { get; set; }
        public Category Category { get; set; }

        /// <summary>
        /// Data type of attribute (string, int, decimal..)
        /// </summary>
        public AttrType AtributeType { get; set; }
        
        /// <summary>
        /// Reference to object's 
        /// </summary>
        public int ProductAttributeComplexTypeDefinitionId { get; set; }
        public ProductAttributeComplexTypeDefinition ProductAttributeComplexTypeDefinition { get; set; }

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
