using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShopSite.Data.Repository;
using ShopSite.Orders.Models;
using ShopSite.Orders.Services;
using ShopSite.Orders.ViewModels;
using ShopSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.Orders.Controllers
{
    public class OrderController : Controller
    {
        private IWorkContext _workContext;
        private IOrderService _orderService;
        private IRepository<Order> _orderRepo;

        public OrderController(IWorkContext workContext, IOrderService orderService, IRepository<Order> orderRepo)
        {
            _workContext = workContext;
            _orderService = orderService;
            _orderRepo = orderRepo;
        }

        public IActionResult Index()
        {
            return RedirectToAction("OrderInformation");
        }

        [HttpGet]
        public async Task<IActionResult> Checkout()
        {
            var model = new OrderInformationVm();

            var curretUser = await _workContext.GetCurrentUser();

            // temp 
            model.OrderAddress.AddressLine1 = "Adr1";
            model.OrderAddress.AddressLine2 = "Adr2";
            model.OrderAddress.AddressLine3 = "Adr3";

            model.OrderAddress.ContactName = "contact Name";

            model.OrderAddress.Phone = "Hone";
            model.OrderAddress.Region = "Kyivs'ka oblast";
            // Load user's address

            return View("~/Orders/Views/Order/OrderInformation.cshtml",model);
        }

        [HttpPost]
        public async Task<IActionResult> OrderInformation(OrderInformationVm model)
        {
            if (!ModelState.IsValid && (model.OrderAddress != null))
            {
                return View(model);
            }

            var currentUser = await _workContext.GetCurrentUser();

            _orderService.CreateOrder(currentUser, model.OrderAddress);

            return RedirectToAction("OrderConfirmation");
        }

        [HttpGet]
        public IActionResult OrderConfirmation()
        {
            return View();
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult Admin()
        {     
            var q = _orderRepo.Table
                .Include(x => x.CreatedBy).ToList();
            
            return View("~/Orders/Views/Admin/Orders.cshtml", q);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult Admin(string status)
        {
            ViewData["OrderSort"] = string.IsNullOrEmpty(status) ? "orderSort" : "";

            return Admin();
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult OrderDetails(string id)
        {
            var order = _orderRepo.Table
                .Include(x => x.OrderAddress)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product)//.ThenInclude(x => x.ImageUrl) //TODO: fix
                .Include(x => x.CreatedBy)
                .FirstOrDefault(x => x.Id == id);

            if (order == null)
                return new NotFoundResult();

            return View("~/Orders/Views/Admin/OrderDetails.cshtml", order);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult ChangeStatus(string Id, int OrderStatus)
        {
            var order = _orderRepo.Table.FirstOrDefault(x => x.Id == Id);

            if (order == null)
                return NotFound();

            if (Enum.IsDefined(typeof(OrderStatus), OrderStatus))
            {
                order.OrderStatus = (OrderStatus)OrderStatus;
                _orderRepo.Update(order);
                return RedirectToAction("Admin");
            }

            return BadRequest(new { Error = "Could not get status" });
        }
    }
}
