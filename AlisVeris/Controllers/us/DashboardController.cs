using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.us
{
    public class DashboardController : Controller
    {
        // GET: Dashboard
        TicaretEntities db = new TicaretEntities();

        public ActionResult Index()
        {
            DashboardDto model = new DashboardDto();
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
            model.User = db.Users.FirstOrDefault(x => x.Id == ID);
            return View(model);
        }

        public PartialViewResult Menu()
        {


            return PartialView();
        }

        public ActionResult SekilGetr(int Id)
        {
            User nw = db.Users.FirstOrDefault(f => f.Id == Id);

            return View(nw);
        }

        public ActionResult UpdateSekil(User user, HttpPostedFileBase Logo)
        {
            User cm = db.Users.FirstOrDefault(x => x.Id == user.Id);
            
            if (Logo != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Logo.FileName));
                Logo.SaveAs(path);
                cm.Sekil = Path.GetFileName(Logo.FileName);

            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }
        public ActionResult UpdateProfile()
        {

            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
            User nw = db.Users.FirstOrDefault(f => f.Id == ID);


            return View(nw);
        }

        public ActionResult Update(User user)
        {

            User u = db.Users.FirstOrDefault(f => f.Id == user.Id);

            u.Ad = user.Ad;
            u.Soyad = user.Soyad;
            u.Email = user.Email;
            u.Telefon = user.Telefon;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult EditAdres()
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
            User nw = db.Users.FirstOrDefault(f => f.Id == ID);

            return View(nw);
        }

        public ActionResult Edit(User user)
        {


            User u = db.Users.FirstOrDefault(f => f.Id == user.Id);

            u.Olke = user.Olke;
            u.Seher = user.Seher;
            u.Kuce = user.Kuce;
            u.Apartman = user.Apartman;

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ChangePassword()
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
            User nw = db.Users.FirstOrDefault(f => f.Id == ID);

            return View(nw);
        }

        public ActionResult Change(User user)
        {
            User u = db.Users.FirstOrDefault(f => f.Id == user.Id);

            u.Sifre = user.Sifre;
         

            db.SaveChanges();

            return RedirectToAction("Index");
            
        }


        public ActionResult Order()
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);

            List<Order> orders = db.Orders.Where(x => x.UserId == ID).ToList();
            return View(orders);
        }

        [HttpGet]
        public ActionResult OrderDetay(int id)
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);

            Order o = db.Orders.FirstOrDefault(x => x.Id == id);
            //Checkout checkout = db.Checkouts.FirstOrDefault(x => x.User.Id == ID);
            List<Checkout> checkouts = db.Checkouts.Where(x => /*x.ShoppingCart.UserId == ID && */x.OrderId==o.Id).ToList();
            //List<Order> orders = db.Checkouts.Where(x => /*x.ShoppingCart.UserId == ID && */x.OrderId==ID).ToList();
            ViewBag.umumimebleg = (from x in db.Checkouts.Where(x => x.OrderId == id ) select x.ShoppingCart.UmumiMebleg).Sum();
            ViewBag.cesidSayi = (from x in db.Checkouts.Where(x => x.OrderId == id) select x.ShoppingCart.Say).Sum();
            ViewBag.mehsulSayi = db.Checkouts.Where(x => x.OrderId == id).Count();
            return View(checkouts);
        }

    }
}