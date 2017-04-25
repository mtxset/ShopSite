using ShopSite.Data.Repository;
using ShopSite.Models;

namespace ShopSite.Orders.Models
{
    public class CartItem : BaseEntity
    {
        public string UserId { get; set; }
        public User User { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
        public string OptionValue { get; set; }
    }
}
