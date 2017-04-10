using ShopSite.Models;
using System;

namespace ShopSite.Orders.Models
{
    public class OrderItem
    {
        public int Id { get; set; }

        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal ProductPrice { get; set; }

        public virtual Order Order { get; set; }

        public virtual Product Product { get; set; }
    }
}
