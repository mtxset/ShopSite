using ShopSite.Models;
using System.Threading.Tasks;

namespace ShopSite.Services
{
    public interface IWorkContext
    {
        Task<User> GetCurrentUser();
    }
}
