using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopSite.Models;

namespace ShopSite.ViewModels
{
    public class TempEdit
    {
        public Category Category { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } 
    }
}
