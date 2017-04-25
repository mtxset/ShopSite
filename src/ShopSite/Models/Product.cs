using ShopSite.ProductAttributes.Models;
using ShopSite.ProductOptions.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopSite.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public decimal Price { get; set; }

        public bool IsFeatured { get; set; }
        public bool IsAllowedToOrder { get; set; }

        public int? StockQuantity { get; set; }

        public string ImageUrl { get; set; }

        public IList<ProductCategory> Categories { get; set; } = new List<ProductCategory>();

        public IList<ProductOptionValue> OptionValues { get; set; } = new List<ProductOptionValue>();

        public void AddCategory(ProductCategory category)
        {
            category.Product = this;
            Categories.Add(category);
        }

        public void AddOptionValue(ProductOptionValue optValue)
        {
            optValue.Product = this;
            OptionValues.Add(optValue);
        }
    }
}
