using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.us
{
    public class ContactPageController : Controller
    {
        // GET: ContactPage
        TicaretEntities db = new TicaretEntities();

        [HttpGet]
        public ActionResult Index()
        {
           
            return View(/*"Index"*/);
        }

        [HttpPost]

        public ActionResult Elaqe(Contact c)
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
            User user = db.Users.SingleOrDefault(x => x.Id == ID);
            c.User = db.Users.SingleOrDefault(x => x.Id == ID);

            db.Contacts.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}