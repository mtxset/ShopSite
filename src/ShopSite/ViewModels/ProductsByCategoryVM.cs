using System.Collections.Generic;

namespace ShopSite.ViewModels
{
    public class ProductsByCategoryVM
    {
        public int CategoryId { get; set; }
        public int? ParentCategoryId { get; set; }

        public string CategoryName { get; set; }

        public int TotalProducts { get; set; }

        public SearchOptions SeachOptions { get; set; }

        public decimal MaxPrice { get; set; }
        public decimal MinPrice { get; set; }

        public IList<ProductPreview> Products { get; set; } = new List<ProductPreview>();

        /*
         Filter options
         Search options
         Sort options
         */

    }
}
