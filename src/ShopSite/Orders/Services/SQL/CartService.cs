using System.Collections.Generic;
using ShopSite.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using ShopSite.Orders.Models;
using ShopSite.Models;

namespace ShopSite.Orders.Services.SQL
{
    public class CartService : ICartService
    {
        private IRepository<CartItem> _cartItemRepository;

        public CartService(IRepository<CartItem> cartService)
        {
            _cartItemRepository = cartService;
        }

        public CartItem AddToCart(User user, int productId, int quantity)
        {
            // Get data from user(userId) filled with product(productId) from cartItem table
            var cartItem = _cartItemRepository.Table
                .Include(x => x.Product)
                .Where(x => x.ProductId == productId && x.UserId == user.Id).FirstOrDefault();

            // Adding new, else just increasing quantity
            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    UserId = user.Id,
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

        public IList<CartItem> GetCartItems(User user)
        {
            return _cartItemRepository.Table
                .Include(x => x.Product)//.ThenInclude(p => p.ImageUrl) //TODO: fix
                .Where(x => x.UserId== user.Id).ToList();
        }
    }
}
