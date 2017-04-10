using ShopSite.Data.Repository;
using System;
using System.Collections.Generic;

namespace ShopSite.Models.Order
{
    public class Order : BaseEntity
    {
        public Order()
        {
            CreatedOn = DateTimeOffset.Now;
            OrderStatus = OrderStatus.Pending;
        }

        public DateTimeOffset CreatedOn { get; set; }

        public OrderStatus OrderStatus { get; set; }

        public int CreatedById { get; set; }

        public User CreatedBy { get; set; }

        public decimal SubTotal { get; set; }

        public OrderAddress OrderAddress { get; set; }

        public IList<OrderItem> OrderItems { get; set; } = new List<OrderItem>();

        public void AddOrderItem(OrderItem item)
        {
            OrderItems.Add(item);
        }
    }
}
