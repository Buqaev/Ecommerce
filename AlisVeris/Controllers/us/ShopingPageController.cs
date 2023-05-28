using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.us
{
    public class ShopingPageController : Controller
    {
        // GET: ShopingPage
        TicaretEntities db = new TicaretEntities();

        public ActionResult Index(/*int? Id*/ )
        {
            List<ShoppingCart> shoppings = new List<ShoppingCart>();
            string Id = Session["Id"]?.ToString();
            if (Id!=null)
            {
                int? ID = int.Parse(Id);

                List<ShoppingCart> shoppingCarts = db.ShoppingCarts.Where(x => x.UserId == ID && x.Status==true).ToList();

                ShoppingCart shoppingCart = db.ShoppingCarts.FirstOrDefault(x => x.UserId == ID && x.Status == true);

                if (shoppingCarts.Count()!= 0 && shoppingCart.Status==true)
                {
                    ViewBag.mehsulSayi = db.ShoppingCarts.Where(x => x.UserId == ID && x.Status == true).Count();
                    ViewBag.cesidSayi = (from x in db.ShoppingCarts.Where(x => x.UserId == ID && x.Status == true) select x.Say).Sum();
                    ViewBag.mebleg = (from x in db.ShoppingCarts.Where(x => x.UserId == ID && x.Status == true) select x.UmumiMebleg).Sum();
                }
               

                return View(shoppingCarts);
            }

            return View();
            
        }

        public ActionResult UpdateCart(/*ShoppingCart shop*/int? id)
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
            int satir = 0;
            var data = db.ShoppingCarts.Where(x => x.UserId == ID && x.Status == true).ToList();

            //  ShoppingCart s = db.ShoppingCarts.FirstOrDefault(x => x.Id == shop.Id);
            // List<ShoppingCart> s = db.ShoppingCarts.Where(x=>x.Status==false)

            ShoppingCart sepet = db.ShoppingCarts.FirstOrDefault(x=> x.ProductId==ID);


            //foreach (var x in data)
            //{
            //    var satis = new ShoppingCart
            //    {
            //        ProductId = 3,
            //        //UserId = data[satir].UserId
            //        UserId=ID,
                   
            //        Qiymet = shop.Qiymet,
            //        Say=shop.Say,
            //        UmumiMebleg=shop.UmumiMebleg,
                    
                    
            //    };
            //    Product products = db.Products.SingleOrDefault(z => z.Id == x.ProductId);


            //    int a = (from y in db.ShoppingCarts.Where(j => j.Product.Id == products.Id && j.UserId == ID) select y.Say).Sum();
            //    products.StokSayi = products.StokSayi - a;


                


            //    db.SaveChanges();
            //    satir++;

            //}



  


            return View();
        }

        public ActionResult Delate(int Id)
        {
            ShoppingCart ktg = db.ShoppingCarts.FirstOrDefault(x=>x.Id==Id);
            ktg.Status = false;
            db.SaveChanges();

            return RedirectToAction("Index");
            
        }

        public ActionResult Artir(int id)
        {
            //Product data = db.Products.FirstOrDefault(x => x.Id == id);

            ShoppingCart model = db.ShoppingCarts.FirstOrDefault(x => x.Id == id);
            if (model.Product.StokSayi>model.Say)
            {
                model.Say++;
                model.UmumiMebleg = model.Say * model.Qiymet;
                db.SaveChanges();
            }
           

            return RedirectToAction("Index");
        }

        public ActionResult Azalt(int id)
        {
            ShoppingCart model = db.ShoppingCarts.FirstOrDefault(x => x.Id == id);
            if (model.Say>1)
            {
                model.Say--;
                model.UmumiMebleg = model.Say * model.Qiymet;
                db.SaveChanges();
            }
           
            

            return RedirectToAction("Index");
        }


    }
}