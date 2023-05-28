using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;

namespace AlisVeris.Controllers.ad
{
    public class AdminController : Controller
    {
        // GET: Admin
        TicaretEntities db = new TicaretEntities();
        public ActionResult Index()
        {
            List<Admin> admin = db.Admins.ToList();

            return View(admin);
        }
        public ActionResult UpdateAdmin(int Id)
        {
            Admin admin = db.Admins.FirstOrDefault(x => x.Id == Id);

            return View(admin);
        }

        public ActionResult Update(Admin a)
        {
            Admin admin = db.Admins.FirstOrDefault(x => x.Id == a.Id);
            admin.Ad = a.Ad;
            admin.Soyad = a.Soyad;
            admin.Email = a.Email;
            admin.Nomre = a.Nomre;
            admin.Sifre = a.Sifre;
            admin.Id = a.Id;
            
            db.SaveChanges();
            return RedirectToAction("Index");

        }
    }
}