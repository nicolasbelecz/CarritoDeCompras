using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models.TableViewModel
{
    public class OrderTableViewModel
    {
        public int id { get; set; }
        public DateTime? fecha { get; set; }
        public decimal? total { get; set; }

    }
}