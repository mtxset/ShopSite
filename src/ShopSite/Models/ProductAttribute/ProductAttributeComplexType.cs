using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.Models
{
    public class ProductAttributeCompexType
    {
        public int Id { get; set; }
        public int? ValueId { get; set; }
        public int ProductId { get; set; }
        public int AtributeNameId { get; set; }

        public ProductAttributeComplexTypeDefinition Value { get; set; }

        public Product Product { get; set; }
        public ProductAttribute AtributeName { get; set; }
    }
}