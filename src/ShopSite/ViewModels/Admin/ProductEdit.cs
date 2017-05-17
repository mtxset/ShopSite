using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
using ShopSite.ProductOptions.ViewModels;
using ShopSite.ProductAttributes.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace ShopSite.ViewModels.Admin
{
    public class ProductEdit
    {
        public Models.Product Product { get; set; }
        public Models.Category Category { get; set; }

        public IList<SelectListItem> Categories { get; set; } 
        
        //public IList<bool> SelectedCategories { get; set; }

        public bool EditImageUrl { get; set; }

        public IFormFile File { get; set; }

        public IList<ProductOptionVm> Options { get; set; }

        [Required]
        public int SelectedCategory { get; set; }

        public IList<ProductAttributeVm> ProductAttributes { get; set; } = new List<ProductAttributeVm>();

        public IList<ProductAttributeCompTVm> ProductAttributesCompT { get; set; } = new List<ProductAttributeCompTVm>();
    }
}
