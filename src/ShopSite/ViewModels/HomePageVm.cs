using ShopSite.Services;

namespace ShopSite.ViewModels
{
    public class HomePageVm
    {
        public int IndexPage { get; set; }

        public IPagedList<ProductPreview> Products { get; set; }
    }
}
