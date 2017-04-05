using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.Models
{
    public class ProductAttributeInt
    {
        public int Id { get; set; }
        public int Value { get; set; }
        public int ProductId { get; set; }
        public int AtributeNameId { get; set; }

        public Product Product { get; set; }
        public ProductAttribute AtributeName { get; set; }
    }
}