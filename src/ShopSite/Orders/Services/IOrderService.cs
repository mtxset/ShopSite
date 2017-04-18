using ShopSite.Models;
using ShopSite.Orders.Models;

namespace ShopSite.Orders.Services
{
    public interface IOrderService
    {
        void CreateOrder(string userId, OrderAddress address);
    }
}
