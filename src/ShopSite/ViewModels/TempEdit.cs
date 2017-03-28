using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopSite.Models;

namespace ShopSite.ViewModels
{
    public class TempEdit
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int ParentId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } 
    }
}
