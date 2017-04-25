using System.Collections.Generic;

namespace ShopSite.ProductOptions.ViewModels
{
    public class ProductOptionVm
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public IList<string> Values { get; set; } = new List<string>();
    }
}
