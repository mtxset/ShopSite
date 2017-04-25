using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using ShopSite.Data.Repository;
using ShopSite.Orders.Models;
using ShopSite.Orders.Services;
using ShopSite.Orders.ViewModels;
using ShopSite.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.Orders.Controllers
{
    public class OrderController : Controller
    {
        private IWorkContext _workContext;
        private IOrderService _orderService;
        private IRepository<Order> _orderRepo;
        private int ordersPageSize;

        public OrderController(
            IWorkContext workContext, 
            IOrderService orderService, 
            IRepository<Order> orderRepo, 
            IConfiguration config)
        {
            _workContext = workContext;
            _orderService = orderService;
            _orderRepo = orderRepo;
            ordersPageSize = config.GetValue<int>("OrdersPageSize");
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
            // TODO: Load User's address

            return View("~/Orders/Views/Order/OrderInformation.cshtml", model);
        }

        [HttpPost]
        public async Task<IActionResult> OrderInformation(OrderInformationVm model)
        {
            if (!ModelState.IsValid && (model.OrderAddress != null))
                return View(model);

            var currentUser = await _workContext.GetCurrentUser();

            _orderService.CreateOrder(currentUser.Id, model.OrderAddress);

            return RedirectToAction("OrderConfirmation");
        }

        [HttpGet]
        public IActionResult OrderConfirmation()
        {
            return View("~/Orders/Views/Order/OrderConfirmation.cshtml");
        }

        [HttpGet]
        [Authorize(Roles ="admin")]
        public IActionResult Admin(string currentFilter, string sortOrder, string searchString, int? statusId, int? page)
        {
            ViewData["CurrentSort"] = sortOrder;
            ViewData["SubTotalParm"] = string.IsNullOrEmpty(sortOrder) ? "subtotal" : "subtotal_desc";
            ViewData["DateSortParm"] = sortOrder == "date" ? "date_desc" : "date";

            if (searchString != null)
                page = 0;
            else
                searchString = currentFilter;

            ViewData["CurrentFilter"] = searchString;

            IQueryable<Order> q = _orderRepo.Table
                .Include(x => x.CreatedBy);

            if (!String.IsNullOrEmpty(searchString))
                q = q.Where(x => x.CreatedBy.UserName == searchString);

            if (statusId != null && statusId != 0)
            {
                var status = (OrderStatus)statusId;
                q = q.Where(x => x.OrderStatus == status);

                page = 0;
            }

            switch (sortOrder)
            {
                case "date":
                    q = q.OrderBy(x => x.CreatedOn);
                    break;
                case "date_desc":
                    q = q.OrderByDescending(x => x.CreatedOn);
                    break;
                case "subtotal":
                    q = q.OrderBy(x => x.SubTotal);
                    break;
                case "subtotal_desc":
                    q = q.OrderByDescending(x => x.SubTotal);
                    break;
            }

            var model = new OrderListVm
            {
                Orders = new PagedList<Order>(q.ToList(), page ?? 0, ordersPageSize)
            };
            
            return View("~/Orders/Views/Admin/Orders.cshtml", model);
        }

        [HttpGet]
        [Authorize(Roles = "admin")]
        public IActionResult OrderDetails(int id)
        {
            var order = _orderRepo.Table
                .Include(x => x.OrderAddress)
                .Include(x => x.OrderItems).ThenInclude(x => x.Product)
                .Include(x => x.CreatedBy)
                .FirstOrDefault(x => x.Id == id);

            if (order == null)
                return new NotFoundResult();

            return View("~/Orders/Views/Admin/OrderDetails.cshtml", order);
        }

        [HttpPost]
        [Authorize(Roles = "admin")]
        public IActionResult ChangeStatus(int Id, int OrderStatus)
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

        [HttpGet]
        public async Task<IActionResult> OrderHistory()
        {
            var currentUser = await _workContext.GetCurrentUser();

            var model = _orderRepo.Table
                .Include(x => x.OrderItems).ThenInclude(x => x.Product)
                .Where(x => x.CreatedById == currentUser.Id).ToList();

            return View("~/Orders/Views/Order/OrderHistory.cshtml", model);
        }
    }
}
