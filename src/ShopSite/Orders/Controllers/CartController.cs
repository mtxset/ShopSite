using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ShopSite.Orders.ViewModels;
using ShopSite.Orders.Services;
using ShopSite.Services;
using ShopSite.Orders.Models;
using ShopSite.Data.Repository;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace ShopSite.Orders.Controllers
{
    public class CartController : Controller
    {
        private IRepository<CartItem> _cartItemRepo;
        private ICartService _cartService;
        private IWorkContext _workContext;

        public CartController(ICartService cartService, IWorkContext workContext, IRepository<CartItem> cartItemRepo)
        {
            _cartService = cartService;
            _workContext = workContext;
            _cartItemRepo = cartItemRepo;
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart([FromBody] AddToCartVM model)
        {
            var currentUser = await _workContext.GetCurrentUser();

            CartItem cartItem = _cartService.AddToCart(currentUser, model.ProductId, model.Quantity);

            return RedirectToAction("AddToCartResult", new { cartItemId = cartItem.Id });
        }

        [HttpGet]
        public async Task<IActionResult> AddToCartResult(string cartItemId)
        {
            var currentUser = await _workContext.GetCurrentUser();

            var cartItem = _cartItemRepo.Table
                .Include(x => x.Product)//.ThenInclude(x => x.ImageUrl) //TODO: fix
                .FirstAsync(x => x.Id == cartItemId).Result;

            var model = new AddToCartResultVM
            {
                ProductName = cartItem.Product.Name,
                //ProductImage = cartItem.Product.ImageUrl, // TODO: fix
                ProductPrice = cartItem.Product.Price,
                Quantity = cartItem.Quantity
            };

            var cartItems = _cartService.GetCartItems(currentUser);

            model.CartItemCount = cartItems.Count;
            model.CartAmount = cartItems.Sum(x => x.Quantity * x.Product.Price);

            return PartialView("~/Orders/Views/Cart/AddToCartResult.cshtml", model);
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var currentUser = await _workContext.GetCurrentUser();
            var cartItems = _cartService.GetCartItems(currentUser);

            var model = new CartVM
            {
                CartItems = cartItems.Select(x => new CartListItem
                {
                    Id = x.Id,
                    ProductName = x.Product.Name,
                    ProductPrice = x.Product.Price,
                    //ProductImageUrl = x.Product.ImageUrl, // TODO: fix
                    Quantity = x.Quantity
                }).ToList()
            };

            return View("~/Orders/Views/Cart/Index.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update([FromBody] string id, [FromBody] int quantity)
        {
            return await Index();
        }

        [HttpPost]
        public async Task<IActionResult> Remove(string id)
        {
            var cartItem = _cartItemRepo.Table
                .FirstOrDefaultAsync(x => x.Id == id).Result;
            if (cartItem == null)
            {
                return new NotFoundResult();
            }

            _cartItemRepo.Delete(cartItem);

            return await Index();
        }
        
    }
}