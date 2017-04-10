using Microsoft.AspNetCore.Mvc;
using ShopSite.Data.Repository;
using ShopSite.Models.Order;

namespace ShopSite.Controllers
{
    public class OrderController : Controller
    {
        private IRepository<Order> _orderRepository;

        public OrderController(IRepository<Order> orderRepository)
        {
            _orderRepository = orderRepository;
        }


    }
}
