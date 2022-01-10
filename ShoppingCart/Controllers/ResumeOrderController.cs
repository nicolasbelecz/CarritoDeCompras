using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models.TableViewModel;
using ShoppingCart.Models;


namespace ShoppingCart.Controllers
{
    public class ResumeOrderController : Controller
    {
        // GET: ResumeOrder
        public ActionResult ResumeOrder()
        {
            List<OrderTableViewModel> list = null;
            using (ShoppingCartEntities1 db = new ShoppingCartEntities1())
            {
                list = (from d in db.Pedido
                        select new OrderTableViewModel
                        {
                            id = d.id,
                            fecha = d.fecha,
                            total = d.total
                        }).ToList();
            }
            return View(list);

        }
    }
}