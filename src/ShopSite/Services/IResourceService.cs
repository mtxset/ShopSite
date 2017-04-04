using ShopSite.Localization.Models;
using System.Linq;

namespace ShopSite.Services
{
    public interface IResourceService
    {
        IQueryable<Resource> Query();
    }
}
