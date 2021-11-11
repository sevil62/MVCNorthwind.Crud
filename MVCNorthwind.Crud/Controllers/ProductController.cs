using MVCNorthwind.Crud.DesignPatterns.SingletonPattern;
using MVCNorthwind.Crud.Models;
using MVCNorthwind.Crud.VMClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCNorthwind.Crud.Controllers
{
    public class ProductController : Controller
    {
        NorthwindEntities _db;
        public ProductController()
        {
            _db = DBTool.DBInstance;
        }
        // GET: Product
        public ActionResult ProductList()
        {
            ProductVM pvm = new ProductVM
            {
                Products=_db.Products.ToList(),

            };
            return View(pvm);
        }

        public ActionResult AddProduct()
        {
            ProductVM pvm = new ProductVM
            {
                Categories=_db.Categories.ToList()
            };
           
            return View(pvm);
        }

        [HttpPost]
        public ActionResult AddProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult UpdateProduct(int id)
        {
            ProductVM pvm = new ProductVM
            {
                Product = _db.Products.Find(id),
                Categories = _db.Categories.ToList()
            };
            return View(pvm);
        }

        [HttpPost]
        public ActionResult UpdateProduct(Product product)
        {
            Product guncellenecek = _db.Products.Find(product);
            _db.Entry(guncellenecek).CurrentValues.SetValues(product);
            _db.SaveChanges();
            return RedirectToAction("ProductList");
        }

        public ActionResult DeleteProduct(int id)
        {
            _db.Products.Remove(_db.Products.Find(id));
            _db.SaveChanges();
            return RedirectToAction("ProductList");
        }

    }
}