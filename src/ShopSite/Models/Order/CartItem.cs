using ShopSite.Data.Repository;

namespace ShopSite.Models.Order
{
    public class CartItem : BaseEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
