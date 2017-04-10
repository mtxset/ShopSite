namespace ShopSite.Orders.ViewModels
{
    public class CartListItem
    {
        public string Id { get; set; }

        public string ProductName { get; set; }
        public string ProductImageUrl { get; set; }

        public decimal ProductPrice { get; set; }
        
        public int Quantity { get; set; }

        public decimal Total => Quantity * ProductPrice;
    }
}
