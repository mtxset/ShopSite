using ShopSite.Orders.Models;

namespace ShopSite.Orders.ViewModels
{
    public class OrderInformationVm
    {
        public OrderAddress OrderAddress { get; set; } = new OrderAddress();
    }
}
