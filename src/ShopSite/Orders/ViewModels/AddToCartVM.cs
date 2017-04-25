using System.Collections.Generic;

namespace ShopSite.Orders.ViewModels
{
    public class AddToCartVM
    {
        public int ProductId { get; set; }

        public int Quantity { get; set; }

        public string Option { get; set; }
    }
}
