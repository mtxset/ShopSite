using System.Collections.Generic;

namespace ShopSite.ViewModels
{
    public class SearchOptions
    {
        public string Sort { get; set; }

        public int Page { get; set; }
        public int PageSize { get; set; }

        public int? SearchMinPrice { get; set; }
        public int? SearchMaxPrice { get; set; }
    }
}
