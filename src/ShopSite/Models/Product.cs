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

        public IList<ProductCategory> Categories { get; set; } = new List<ProductCategory>();
        public IList<ProductAttributeValue> AttributeValues { get; set; } = new List<ProductAttributeValue>();

        public void AddCategory(ProductCategory category)
        {
            category.Product = this;
            Categories.Add(category);
        }

        public void AddAttribute(ProductAttributeValue attributeValue)
        {
            attributeValue.Product = this;
            AttributeValues.Add(attributeValue);
        }

    }
}
