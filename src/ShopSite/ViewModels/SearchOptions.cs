﻿namespace ShopSite.ViewModels
{
    public class SearchOptions
    {
        public string CurrentFilter { get; set; }
        public string SortOrder { get; set; }
        public string SearchString { get; set; }

        public string Category { get; set; }

        public int? IndexPage { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public int? SearchMinPrice { get; set; }
        public int? SearchMaxPrice { get; set; }

        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}

