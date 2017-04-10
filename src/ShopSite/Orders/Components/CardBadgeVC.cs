using Microsoft.AspNetCore.Mvc;
using ShopSite.Orders.Services;
using System.Linq;
using System.Threading.Tasks;
using ShopSite.Services;

namespace ShopSite.Orders.Components
{
    /// <summary>
    /// Cart Badge View Component
    /// </summary>
    [ViewComponent]
    public class CartBadge : ViewComponent
    {
        private ICartService _cartService;
        private IWorkContext _workContext;

        public CartBadge(ICartService cartService, IWorkContext workContext)
        {
            _workContext = workContext;
            _cartService = cartService;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var currentUser = await _workContext.GetCurrentUser();
            if (currentUser != null)
            { 
                var cartItemCount = _cartService.GetCartItems(currentUser).Count();

                return View("~/Orders/Views/Components/CartBadge.cshtml", cartItemCount);
            }

            return View("~/Orders/Views/Components/CartBadge.cshtml", 0);
        }
    }
}
