using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.us
{
    public class LikePageController : Controller
    {
        // GET: LikePage
        TicaretEntities db = new TicaretEntities();

        public ActionResult Index()
        {
            string Id = Session["Id"]?.ToString();
            if (Id != null)
            {
                int? ID = int.Parse(Id);

                List<Like> likes = db.Likes.Where(x => x.Status == true && x.UserId==ID).ToList();
                return View(likes);
            }
            return View();
        }

        
        public ActionResult ElavEt(Like l, int Id)
        {
            ProductPageDto model = new ProductPageDto();

            String id = Session["Id"].ToString();  //olmasa burani userId ver
            var ID = int.Parse(id);

            model.user = db.Users.SingleOrDefault(x => x.Id == ID);


            l.Status = true;

            l.Product = db.Products.SingleOrDefault(t => t.Id == Id);      //olmasa c date ele

            l.User = db.Users.SingleOrDefault(x => x.Id == ID);

            db.Likes.Add(l);
            db.SaveChanges();

            return RedirectToAction("Index");


        }
    }
}