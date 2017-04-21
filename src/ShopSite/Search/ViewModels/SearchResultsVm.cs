using ShopSite.Models;
using ShopSite.Services;
using ShopSite.ViewModels;

namespace ShopSite.Search.ViewModels
{
    public class SearchResultsVm
    {
        public string CurrentFilter { get; set; }
        public string SortOrder { get; set; }
        public string SearchString { get; set; }

        public string Category { get; set; }

        public int? IndexPage { get; set; }
        public int Page { get; set; }
        public int PageSize { get; set; }

        public decimal? SearchMinPrice { get; set; }
        public decimal? SearchMaxPrice { get; set; }

        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }

        // TODO put it into SearchOptions

        public IPagedList<ProductPreview> Products { get; set; }
    }
}
