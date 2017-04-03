using System.Collections.Generic;

namespace ShopSite.ViewModels
{
    public class SearchOptions
    {
        public string Sort { get; set; }

        public int? MinPrice { get; set; }
        public int? MaxPrice { get; set; }

        public Dictionary<string, string> ToDictionary()
        {
            var dict = new Dictionary<string, string>();

            if (MinPrice.HasValue)
                dict.Add("minPrice", MinPrice.Value.ToString());

            if (MaxPrice.HasValue)
                dict.Add("maxPrice", MaxPrice.Value.ToString());

            return dict;
        }
    }
}
