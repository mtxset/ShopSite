using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ShopSite.ViewModels.Admin
{
    public class CategoryEdit
    {
        [Required, MaxLength(80)]
        [DataType(DataType.Text)]
        public string Name { get; set; }

        public string Description { get; set; }

        public int ParentId { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; } 
    }
}
