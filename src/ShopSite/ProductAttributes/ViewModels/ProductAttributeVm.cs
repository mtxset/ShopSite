using static ShopSite.ProductAttributes.Models.ProductAttribute;

namespace ShopSite.ProductAttributes.ViewModels
{
    public class ProductAttributeVm
    {
        public int ProductAttributeId { get; set; }
        public AttrType AttrType { get; set; }
        public string Value { get; set; }
    }
}
