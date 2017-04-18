using System.ComponentModel.DataAnnotations;

namespace ShopSite.ProductAttributes.Models
{
    public class ProductAttributeComplexTypeDefinition
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int? ParentId { get; set; }

        public ProductAttributeComplexTypeDefinition Parent { get; set; }
    }
}
