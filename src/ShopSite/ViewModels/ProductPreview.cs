namespace ShopSite.ViewModels
{
    public class ProductPreview
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal Price { get; set; }
        
        public string ImageUrl { get; set; }

        public string ShortDescription { get; set; }

        public int? StockQuantity { get; set; }
    }
}