using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ShoppingCart.Models;
using ShoppingCart.Models.TableViewModel;
using ShoppingCart.Models.ViewModels;

namespace ShoppingCart.Controllers
{
    public class ProductController : Controller
    {
        // GET: Shop
        public ActionResult Product()
        {
            List<ProductTableViewModel> list = null;
            using(ShoppingCartEntities1 db = new ShoppingCartEntities1())
            {
                list = (from d in db.Producto
                        orderby d.nombre
                        select new ProductTableViewModel
                        {
                            id=d.id,
                            nombre = d.nombre,
                            descripcion = d.descripcion,
                            precio = d.precio
                        }).ToList();
            }
            return View(list);
        }

        [HttpGet]
        public  ActionResult AddProduct()
        {

            return View();
        }
        
        [HttpPost]
        public ActionResult AddProduct(ProductViewModel model)
        {
            if(!ModelState.IsValid)
            {
                return View(model);
            }

            using (var db = new ShoppingCartEntities1())
            {
                Producto oProduct = new Producto();
                oProduct.nombre = model.nombre;
                oProduct.descripcion = model.descripcion;
                oProduct.precio = model.precio;

                db.Producto.Add(oProduct);

                db.SaveChanges();

            }

            return Redirect(Url.Content("~/Product/Product"));
        }

        [HttpGet]
        public ActionResult EditProduct(int id)
        {
            EditProductViewModel model = new EditProductViewModel();

            using(var db = new ShoppingCartEntities1())
            {
                var oProduct = db.Producto.Find(id);
                model.nombre = oProduct.nombre;
                model.descripcion = oProduct.descripcion;
                model.precio = oProduct.precio;
                model.id = oProduct.id;
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult EditProduct(EditProductViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            using(var db = new ShoppingCartEntities1())
            {
                var oProduct = db.Producto.Find(model.id);
                oProduct.nombre = model.nombre;
                oProduct.descripcion = model.descripcion;
                oProduct.precio = model.precio;

                db.Entry(oProduct).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }

            

            return Redirect(Url.Content("~/Product/Product"));
        }

        [HttpGet]
        public ActionResult DeleteProduct(int id)
        {
            DeleteProductViewModel model = new DeleteProductViewModel();

            using (var db = new ShoppingCartEntities1())
            {
                var oProduct = db.Producto.Find(id);
                model.nombre = oProduct.nombre;
                model.descripcion = oProduct.descripcion;
                model.precio = oProduct.precio;
                model.id = oProduct.id;
            }

            return View(model);
            
        }
        [HttpPost]
        public ActionResult DeleteProduct(DeleteProductViewModel model)
        {
            using (var db = new ShoppingCartEntities1())
            {
                var oProduct = db.Producto.Find(model.id);
                oProduct.nombre = "deleted";


                db.Producto.Remove(oProduct);
                db.SaveChanges();
            }

            return Redirect(Url.Content("~/Product/Product"));
        }

        

      

        
    }
}