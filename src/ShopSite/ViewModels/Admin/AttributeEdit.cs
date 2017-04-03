using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopSite.ViewModels.Admin
{
    public class AttributeEdit
    {
        [Required]
        public string Name { get; set; }

        public IList<SelectListItem> Groups { get; set; } 

        public int GroupId { get; set; }
    }
}
