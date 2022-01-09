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
            using (ShoppingCartEntities1 db = new ShoppingCartEntities1())
            {
                Pedido oPedido = new Pedido();

                db.Pedido.Add(oPedido);

                db.SaveChanges();

                foreach (var oDetalle in model.detalles)
                {
                    detalles det = new detalles();
                    det.cantidad = oDetalle.cantidad;
                    det.idProducto = oDetalle.idProducto;
                    det.precio = oDetalle.precio;
                    det.precioRenglon = oDetalle.cantidad * oDetalle.precio;
                    det.idPedido = oPedido.id;
                }

                db.SaveChanges();
            }

            ViewBag.Message = "Pedido Insertado";
            return View();

        }

        [HttpPost]
        public ActionResult DeleteItem(int id)
        {
            OrderViewModel model = new OrderViewModel();

            detalles det = new detalles();

            det.idProducto = id;

            model.detalles.Remove(det);

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


    }
}