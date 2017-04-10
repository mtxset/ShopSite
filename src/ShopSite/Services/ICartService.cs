using ShopSite.Models.Order;
using System.Collections.Generic;

namespace ShopSite.Services
{
    public interface ICartService
    {
        CartItem AddToCart(int userId, int productId, int quantity);

        IList<CartItem> GetCartItems(int userId);
    }
}
