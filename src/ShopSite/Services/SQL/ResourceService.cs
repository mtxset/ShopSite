using System.Linq;
using ShopSite.Data;
using ShopSite.Localization.Models;

namespace ShopSite.Services.SQL
{
    public class ResourceService : IResourceService
    {
        private ShopSiteDbContext _context;

        public ResourceService(ShopSiteDbContext context)
        {
            _context = context;
        }

        public IQueryable<Resource> Query()
        {
            return _context.Resources;
        }
    }
}
