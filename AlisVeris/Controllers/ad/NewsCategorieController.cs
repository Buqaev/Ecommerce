using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.ad
{
    public class NewsCategorieController : Controller
    {
        // GET: NewsCategorie
        TicaretEntities db = new TicaretEntities();
        public ActionResult Index()
        {
            List<NewsCategory> categories = db.NewsCategories.Where(x=>x.Status==true).ToList();

            return View(categories);
        }

        [HttpGet]
        public ActionResult CreateCategory()
        {
            List<NewsCategory> categories = db.NewsCategories.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(NewsCategory category)
        {


          
            category.Status = true;
            db.NewsCategories.Add(category);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CategoryUpdate(int Id)
        {
            NewsCategory category = db.NewsCategories.FirstOrDefault(x => x.Id == Id);

            return View(category);
        }

        public ActionResult Update(NewsCategory category)
        {
            NewsCategory p = db.NewsCategories.FirstOrDefault(x => x.Id == category.Id);
            p.Ad = category.Ad;

            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Delate(int Id)
        {
            NewsCategory category = db.NewsCategories.FirstOrDefault(x => x.Id == Id);
            category.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}