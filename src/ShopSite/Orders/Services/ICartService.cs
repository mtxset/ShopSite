using ShopSite.Models;
using ShopSite.Orders.Models;
using System.Collections.Generic;

namespace ShopSite.Orders.Services
{
    public interface ICartService
    {
        CartItem AddToCart(string userId, int productId, int quantity, string optionValue);

        IList<CartItem> GetCartItems(string userId);
    }
}
