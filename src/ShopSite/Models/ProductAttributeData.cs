using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShopSite.Models
{
    public class ProductAttributeData
    {
        public int Id { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Value { get; set; }

        public int ProductId { get; set; }
        public int AtributeNameId { get; set; }

        public Product Product { get; set; }
        public ProductAttribute AtributeName { get; set; }
    }
}