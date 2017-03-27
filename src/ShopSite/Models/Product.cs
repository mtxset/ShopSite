using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.Models
{
    public class Product
    {
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsFeatured { get; set; }
        public bool IsAllowedToOrder { get; set; }

        public int? StockQuantity { get; set; }

        public IList<ProductCategory> Categories { get; protected set; } = new List<ProductCategory>();

    }
}
