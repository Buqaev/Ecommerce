using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using AlisVeris.Models;
namespace AlisVeris.Controllers.us
{
    [AllowAnonymous]
    public class UserController : Controller
    {
        // GET: User

        TicaretEntities db = new TicaretEntities();

        
        public ActionResult Index()
        {
             

            return View();
        }
        
        [AllowAnonymous]
        public ActionResult Register(User user)
        {
            user.Soyad = "Bosdur";
            user.Olke = "Bosdur";
            user.Kuce = "Bosdur";
            user.Apartman = "Bosdur";
            user.Seher = "Bosdur";
            user.Telefon = "Bosdur";
            user.ZipCode = 0;
            user.Sekil = "Bosdur";

            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("Index");


        }
        [HttpGet]
        
     
        public ActionResult UserLogin()
        {


            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(string Mail, string Sifre)
        {
            User user = db.Users.FirstOrDefault(x => x.Email == Mail && x.Sifre == Sifre);

            Admin admin = db.Admins.FirstOrDefault(x => x.Email == Mail && x.Sifre == Sifre);
            if (user != null)
            {

                FormsAuthentication.SetAuthCookie(user.Ad, false);
                Session["Id"] = user.Id.ToString();
                Session["Ad"] = user.Ad.ToString();
                Session["Soyad"] = user.Soyad.ToString();


                Session["LoggedUser"] = user;

                return RedirectToAction("Index", "HomePage");
            }

            if (admin != null)
            {

                FormsAuthentication.SetAuthCookie(admin.Ad, false);
                Session["Id"] = admin.Id.ToString();

                return RedirectToAction("Index", "Admin");
            }
            else
            {
                return RedirectToAction("Index");
            }


        }

        public ActionResult CixisEt()
        {
            FormsAuthentication.SignOut();
            Session["LoggedUser"] = null;
            Session.Abandon();


            return RedirectToAction("Index", "HomePage");
        }
    }
}