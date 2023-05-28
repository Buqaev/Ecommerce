using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;

namespace AlisVeris.Controllers.ad
{
    [AllowAnonymous]
    public class NewsController : Controller
    {
        // GET: News
        TicaretEntities db = new TicaretEntities();

        public ActionResult Index()
        {
            List<News> news = db.News.Where(x => x.Status == true).ToList();

            return View(news);
        }

        [HttpGet]
        public ActionResult CreateNews()
        {
            List<News> news = db.News.ToList();
            List<NewsCategory> newsCategories = db.NewsCategories.Where(x => x.Status == true).ToList();
            return View(newsCategories);
        }

        [HttpPost]
        public ActionResult Create(News news, HttpPostedFileBase Sekil)
        {


            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                news.Sekil = Path.GetFileName(Sekil.FileName);

            }
            news.Status = true;
            db.News.Add(news);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult NewsUpdate(int Id)
        {
            News news = db.News.FirstOrDefault(x => x.Id == Id);
            ViewBag.cate = db.NewsCategories.Where(x => x.Status == true).ToList();
            return View(news);
        }

        public ActionResult Update(News news, HttpPostedFileBase Sekil)
        {
            News n= db.News.FirstOrDefault(x => x.Id == news.Id);
            n.Mezmun = news.Mezmun;
            n.Basliq = news.Basliq;
            n.Metn = news.Metn;

            n.NewsCategoriesId = news.NewsCategoriesId;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                n.Sekil = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delate(int Id)
        {
            News news = db.News.FirstOrDefault(x => x.Id == Id);
            news.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
