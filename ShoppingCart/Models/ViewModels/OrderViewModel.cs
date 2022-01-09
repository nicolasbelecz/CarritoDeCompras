using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ShoppingCart.Models.ViewModels
{
    public class OrderViewModel
    {
        public OrderViewModel()
        {
            detalles = new List<detalles>();
        }
        public int id { get; set; }

         public List<detalles> detalles { get; set; }

        public int cantSelec { get; set; }

        public int idProdSelec { get; set; }


        
    }

    public class detalles
    {
        public int cantidad { get; set; }
        
        public int idProducto { get; set; }

        public string nombreProd { get; set; }

        public decimal precio { get; set; }

        public decimal precioRenglon { get; set; }

        public int idPedido { get; set; }
    }
}