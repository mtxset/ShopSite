using Microsoft.AspNetCore.Mvc;
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
        

        public OrderController(IWorkContext workContext, IOrderService orderService)
        {
            _workContext = workContext;
            _orderService = orderService;
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

    }
}
