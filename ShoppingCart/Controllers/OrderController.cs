using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models.TableViewModel;
using ShoppingCart.Models.ViewModels;
using ShoppingCart.Models;

namespace ShoppingCart.Controllers
{
    public class OrderController : Controller
    {


        // GET: Order
        public ActionResult Order()
        {

            List<SelectListItem> list = new List<SelectListItem>();

            using (Models.ShoppingCartEntities1 db = new Models.ShoppingCartEntities1())
            {
                list = (from d in db.Producto
                        select new SelectListItem
                        {
                            Value = d.id.ToString(),
                            Text = d.nombre
                        }).ToList();
            }

            ViewBag.PRODUCTLIST = list;
            return View(new OrderViewModel());

        }



        [HttpPost]
        public ActionResult Order(OrderViewModel model)
        {
            var oProduct = new Producto();

            using (ShoppingCartEntities1 db = new ShoppingCartEntities1())
            {
                oProduct = db.Producto.Find(model.idProdSelec);

            }

            model.detalles.Add(new detalles
            {
                cantidad = model.cantSelec,
                idProducto = model.idProdSelec,
                nombreProd = oProduct.nombre,
                precio = oProduct.precio.Value,
                precioRenglon = model.cantSelec * oProduct.precio.Value


            });

            List<SelectListItem> list = new List<SelectListItem>();

            using (Models.ShoppingCartEntities1 db = new Models.ShoppingCartEntities1())
            {
                list = (from d in db.Producto
                        select new SelectListItem
                        {
                            Value = d.id.ToString(),
                            Text = d.nombre
                        }).ToList();
            }

            ViewBag.PRODUCTLIST = list;


            return View(model);
        }

        [HttpPost]
        public ActionResult SaveOrder(OrderViewModel model)
        {
            decimal totalOrder = 0;

            using (ShoppingCartEntities1 db = new ShoppingCartEntities1())
            {
                Pedido oPedido = new Pedido();

                oPedido.fecha = DateTime.Now;

                db.Pedido.Add(oPedido);
                db.SaveChanges();



                foreach (var oDetalle in model.detalles)
                {
                    DetallePedido det = new DetallePedido();
                    det.cantidad = oDetalle.cantidad;
                    det.idProducto = oDetalle.idProducto;
                    det.totalRenglon = oDetalle.cantidad * oDetalle.precio;
                    det.idPedido = oPedido.id;

                    totalOrder = totalOrder + (oDetalle.cantidad * oDetalle.precio);

                    db.DetallePedido.Add(det);

                }

                oPedido.total = totalOrder;

                db.SaveChanges();
            }

            ViewBag.Message = "Pedido Insertado";
            return View(ViewBag);

        }
        [HttpPost]
        public ActionResult DeleteItem(OrderViewModel model)
        {
            var DeleteItem = model.detalles.FirstOrDefault(w => w.ActiveFill == true);

            model.detalles.Remove(DeleteItem);

            List<SelectListItem> list = new List<SelectListItem>();

           

            return RedirectToAction("Order","Order",model);
        }
    }
}

        
       
    
