﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.Models
{
    public class ProductAttributeDec
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        public int ProductId { get; set; }
        public int AtributeNameId { get; set; }

        public Product Product { get; set; }
        public ProductAttribute AtributeName { get; set; }
    }
}