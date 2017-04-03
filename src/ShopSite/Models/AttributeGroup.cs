using System.Collections.Generic;

namespace ShopSite.Models
{
    public class AttributeGroup
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual IList<Attribute> Attributes { get; set; } = new List<Attribute>();
    }
}
