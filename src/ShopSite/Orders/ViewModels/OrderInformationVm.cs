using ShopSite.Orders.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopSite.Orders.ViewModels
{
    public class OrderInformationVm
    {
        public OrderAddress OrderAddress { get; set; } = new OrderAddress();
    }
}
