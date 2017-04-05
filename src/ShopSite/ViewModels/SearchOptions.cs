using System.Collections.Generic;

namespace ShopSite.ViewModels
{
    public class SearchOptions
    {
        public string Sort { get; set; }

        public int? Page { get; set; }
        public int? SearchMinPrice { get; set; }
        public int? SearchMaxPrice { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            var dict = new Dictionary<string, string>();

            if (SearchMinPrice.HasValue)
                dict.Add("minPrice", SearchMinPrice.Value.ToString());

            if (SearchMaxPrice.HasValue)
                dict.Add("maxPrice", SearchMaxPrice.Value.ToString());

            return dict;
        }
    }
}
