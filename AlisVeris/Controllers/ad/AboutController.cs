using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;

namespace AlisVeris.Controllers.ad
{
    public class AboutController : Controller
    {
        // GET: About
        TicaretEntities db = new TicaretEntities();

        
        public ActionResult Index()
        {
            List<About> abouts = db.Abouts.ToList();

            return View(abouts);
        }



        public ActionResult UpdateAbout(int Id)
        {
            About about = db.Abouts.FirstOrDefault(x => x.Id == Id);

            return View(about);
        }

        public ActionResult Update(About about)
        {
            About a = db.Abouts.FirstOrDefault(x => x.Id == about.Id);
            a.Ad = about.Ad;
            a.Soyad = about.Soyad;
            a.Veziffe = about.Veziffe;
            a.Basliq = about.Basliq;
            a.Metn = about.Metn;
            
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

   
}