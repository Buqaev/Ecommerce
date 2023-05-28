using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;

namespace AlisVeris.Controllers.ad
{
    public class ProductCategoryController : Controller
    {
        // GET: ProductCategory
        TicaretEntities db = new TicaretEntities();
        public ActionResult Index()
        {
            List<ProductCategory> categories = db.ProductCategories.Where(x => x.Status == true).ToList();

            return View(categories);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            List<ProductCategory> categories = db.ProductCategories.ToList();
            return View(categories);
        }

        [HttpPost]
        public ActionResult Create(ProductCategory category)
        {


            category.Status = true;
            db.ProductCategories.Add(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CategoryUpdate(int Id)
        {
            ProductCategory category = db.ProductCategories.FirstOrDefault(x => x.Id == Id);
            return View(category);
        }

        public ActionResult Update(ProductCategory category)
        {
            ProductCategory n = db.ProductCategories.FirstOrDefault(x => x.Id == category.Id);
            n.Ad = category.Ad;
          


            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delate(int Id)
        {
            ProductCategory category = db.ProductCategories.FirstOrDefault(x => x.Id == Id);
            category.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}