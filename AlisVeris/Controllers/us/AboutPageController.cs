using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.us
{
    public class AboutPageController : Controller
    {
        // GET: AboutPage
        TicaretEntities db = new TicaretEntities();

        public ActionResult Index()
        {
            AboutDto model = new AboutDto();

            model.Abouts = db.Abouts.ToList();
            model.Personnels = db.Personnels.Where(x => x.Status == true).ToList();
            model.Contacts = db.Contacts.ToList();

            ViewBag.mehsulsay = db.Products.Where(x => x.Status).Count();
            ViewBag.isdifadecisay = db.Users.Count();
            return View(model);
        }
    }
}