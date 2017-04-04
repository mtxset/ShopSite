using System.Collections.Generic;

namespace ShopSite.Localization.Models
{
    public class Culture
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public IList<Resource> Resources { get; set; }
    }
}
