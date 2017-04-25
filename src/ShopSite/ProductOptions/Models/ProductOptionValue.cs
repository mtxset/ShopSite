using ShopSite.Data.Repository;
using ShopSite.Models;

namespace ShopSite.ProductOptions.Models
{
    public class ProductOptionValue : BaseEntity
    {
        public int OptionId { get; set; }

        public int ProductId { get; set; }

        public string Value { get; set; }

        public virtual ProductOption Option { get; set; }
        
        public Product Product { get; set; }
    }
}
