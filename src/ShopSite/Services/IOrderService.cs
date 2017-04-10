using ShopSite.Models;
using ShopSite.Models.Order;

namespace ShopSite.Services
{
    public interface IOrderService
    {
        void CreateOrder(User user, OrderAddress address);
    }
}
