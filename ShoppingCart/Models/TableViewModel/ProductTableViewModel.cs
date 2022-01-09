﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models.TableViewModel
{
    public class ProductTableViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public decimal? precio { get; set; }
    }

    public class OrderTableViewModel
    {
        public int id { get; set; }
        public string nombre { get; set; }
        public decimal? precio { get; set; }
    }
}