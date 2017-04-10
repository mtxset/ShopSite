namespace ShopSite.Orders.ViewModels
{
    public class AddToCartResultVM
    {
        public string ProductName { get; set; }

        public string ProductImage { get; set; }

        public decimal ProductPrice { get; set; }

        public int Quantity { get; set; }

        public int CartItemCount { get; set; }

        public decimal CartAmount { get; set; }
    }
}
