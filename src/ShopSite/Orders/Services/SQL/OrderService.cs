using System;
using ShopSite.Models;
using ShopSite.Orders.Models;
using ShopSite.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShopSite.Orders.Services.SQL
{
    public class OrderService : IOrderService
    {
        private IRepository<CartItem> _cartItemRepo;
        private IRepository<Order> _orderRepo;

        public OrderService(IRepository<CartItem> cartItemRepo, IRepository<Order> orderRepo)
        {
            _cartItemRepo = cartItemRepo;
            _orderRepo = orderRepo;
        }

        public void CreateOrder(string userId, OrderAddress address)
        {
            var cartItems = _cartItemRepo.Table
                .Include(x => x.Product)
                .Where(x => x.UserId == userId).ToList();

            var orderAddress = new OrderAddress()
            {
                AddressLine1 = address.AddressLine1,
                AddressLine2 = address.AddressLine2,
                AddressLine3 = address.AddressLine3,
                Phone = address.Phone
            };

            var order = new Order
            {
                CreatedOn = DateTimeOffset.Now,
                CreatedById = userId,
                OrderAddress = address
            };

            foreach (var item in cartItems)
            {
                OrderItem orderItem = new OrderItem
                {
                    Product = item.Product,
                    ProductPrice = item.Product.Price,
                    Quantity = item.Quantity
                };
                order.AddOrderItem(orderItem);

                _cartItemRepo.Delete(item);
            }

            order.SubTotal = order.OrderItems.Sum(x => x.ProductPrice * x.Quantity);
            _orderRepo.Insert(order);
        }
    }
}
