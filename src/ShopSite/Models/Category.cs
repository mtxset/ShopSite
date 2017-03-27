using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ShopSite.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [StringLength(5000)]
        public string Description { get; set; }

        public int? ParentId { get; set; }

        public Category Parent { get; set; }

        public IList<Category> Children { get; protected set; } = new List<Category>();
    }
}
