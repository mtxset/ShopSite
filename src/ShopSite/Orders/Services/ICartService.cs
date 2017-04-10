using ShopSite.Models;
using ShopSite.Orders.Models;
using System.Collections.Generic;

namespace ShopSite.Orders.Services
{
    public interface ICartService
    {
        CartItem AddToCart(User user, int productId, int quantity);

        IList<CartItem> GetCartItems(User user);
    }
}
