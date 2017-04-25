using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

namespace ShopSite.Orders.ViewModels
{
    public class CartVM
    {
        public IList<CartListItem> CartItems { get; set; }

        public string SubTotal => CartItems.Sum(x => x.Total).ToString("C", CultureInfo.CreateSpecificCulture("uk-Ua"));
    }
}
