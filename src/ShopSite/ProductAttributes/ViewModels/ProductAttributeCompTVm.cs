using ShopSite.ProductAttributes.Models;

namespace ShopSite.ProductAttributes.ViewModels
{
    public class ProductAttributeCompTVm
    {
        public int ProductAttributeId { get; set; }

        public int? ProductAttributeComplexTypeDefinitionId { get; set; }
        public ProductAttributeComplexTypeDefinition ProductAttributeComplexTypeDefinition { get; set; }

        public int? ValueId { get; set; }
        public ProductAttributeComplexTypeDefinition Value { get; set; }
    }
}
