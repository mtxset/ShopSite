using System.Collections.Generic;
using ShopSite.Models.Order;
using ShopSite.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ShopSite.Services.SQL
{
    public class CartService : ICartService
    {
        private IRepository<CartItem> _cartItemRepository;

        public CartService(IRepository<CartItem> cartService)
        {
            _cartItemRepository = cartService;
        }

        public CartItem AddToCart(int userId, int productId, int quantity)
        {
            // Get data from user(userId) filled with product(productId) from cartItem table
            var cartItem = _cartItemRepository.Table
                .Include(x => x.Product)
                .Where(x => x.ProductId == productId && x.UserId == userId).FirstOrDefault();

            // Adding new, else just increasing quantity
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    UserId = userId,
                    ProductId = productId,
                    Quantity = quantity
                };

                _cartItemRepository.Insert(cartItem);
            }
            else
            {
                cartItem.Quantity = quantity;
            }

            return cartItem;
        }

        public IList<CartItem> GetCartItems(int userId)
        {
            // TODO: should be updated after adding attributes?
            return _cartItemRepository.Table
                .Include(x => x.Product).ThenInclude(p => p.ImageUrl)
                .Where(x => x.UserId == userId).ToList();
        }
    }
}
