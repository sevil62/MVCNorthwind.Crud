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
    public class CategoryController : Controller
    {
        NorthwindEntities _db;
        public CategoryController()
        {
            _db = DBTool.DBInstance;

        }

        // GET: Category
        public ActionResult CategoryList()
        {
            CategoryVM cvm = new CategoryVM
            {
                Categories=_db.Categories.ToList()
            };

            return View(cvm);
        }

        public ActionResult AddCategory()
        {
            CategoryVM cvm = new CategoryVM
            {
                Categories=_db.Categories.ToList()
            };
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category category)
        {
            _db.Categories.Add(category);
            _db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult UpdateCategory(int id)
        {
            CategoryVM cvm = new CategoryVM
            {
                Category = _db.Categories.Find(id)
            };
            return View(cvm);
        }
        [HttpPost]
        public ActionResult UpdateCategory(Category category)
        {
            Category guncellenecek = _db.Categories.Find(category.CategoryID);
            _db.Entry(guncellenecek).CurrentValues.SetValues(category);
            _db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

        public ActionResult DeleteCategory(int id)
        {
            _db.Categories.Remove(_db.Categories.Find(id));
            _db.SaveChanges();
            return RedirectToAction("CategoryList");
        }

    }
}