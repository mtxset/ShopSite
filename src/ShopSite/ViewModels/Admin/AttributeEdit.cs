using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopSite.ViewModels.Admin
{
    public class AttributeEdit
    {
        public string Name { get; set; }

        public IList<SelectListItem> Groups { get; set; } 

        //[Range(1, int.MaxValue, ErrorMessage = "The Attribute Group field is required.")]
        public int GroupId { get; set; }
    }
}
