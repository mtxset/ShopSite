using System.Collections.Generic;

namespace ShopSite.Models
{
    public class AttributeGroup
    {
        public int Id;

        public string Name;

        public virtual IList<Attribute> Attributes { get; set; } = new List<Attribute>();
    }
}
