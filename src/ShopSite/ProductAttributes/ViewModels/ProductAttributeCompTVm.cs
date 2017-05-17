using Microsoft.AspNetCore.Mvc.Rendering;
using ShopSite.ProductAttributes.Models;
using System.Collections.Generic;

namespace ShopSite.ProductAttributes.ViewModels
{
    public class ProductAttributeCompTVm
    {
        public int ProductAttributeId { get; set; }

        public string ProductAttributeName { get; set; }

        public IList<SelectListItem> ProductAttributeComplexTypeDefinition { get; set; }

        public int? ValueId { get; set; }
        public ProductAttributeComplexTypeDefinition Value { get; set; }
    }
}
