using ShopSite.Orders.Models;
using ShopSite.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.Orders.ViewModels
{
    public class OrderListVm
    {
        public int IndexPage { get;set; }

        public IPagedList<Order> Orders { get; set; }
    }
}
