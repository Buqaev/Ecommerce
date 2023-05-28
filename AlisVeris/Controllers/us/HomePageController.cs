using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;


namespace AlisVeris.Controllers.us
{
   // [AllowAnonymous]
    public class HomePageController : Controller
    {
        // GET: HomePage
        TicaretEntities db = new TicaretEntities();

        // [AllowAnonymous]
        public ActionResult Index(int? CarId, int? CateId,int? CateId2,int? NewsId,int? CateId3)
        {
            HomeDto model = new HomeDto();

            model.products = db.Products.Where(x => x.Status == true).ToList();
            model.categories = db.ProductCategories.Where(x => x.Status == true).ToList();
            model.Categories3 = db.ProductCategories.OrderByDescending(x => x.Id).Take(6).ToList();

            model.categories2 = db.ProductCategories.Where(x => x.Status == true).ToList();
            //model.cars = db.Cars.Where(x => x.Status == true).ToList();
            model.cars2 = db.Cars.Where(x => x.Status == true).ToList();
            model.cars = db.Cars.OrderBy(x => x.Id).Take(5).ToList();
            model.Products2 = db.Products.Where(x => x.Status == true && x.ProductCategoryaId== x.ProductCategory.Id).ToList();
            model.NewsCategories = db.NewsCategories.OrderByDescending(x => x.Id).Take(4).ToList();
            
            model.UlduzQiymet = db.ProductReviews.Where(x => x.Status == true).OrderByDescending(x => x.Ulduzsayi).Take(3).ToList();
            model.MinQiymet = db.Products.OrderBy(p => p.SatisQiymeti).First();
            //model.ShoppingCarts = db.ShoppingCarts.Where(x => x.Status==false).Take(3).ToList();
            //List<int> say = (from x in db.ShoppingCarts.Where(w => w.ProductId==w.Product.Id ) select x.Say).ToList();
            // List<int> c= db.Products.Where(t => t.Id == (db.ShoppingCarts.GroupBy(x => x.ProductId).ToList().OrderByDescending(z => z.Count()).Select(x => x.Key).FirstOrDefault())).Select(k => k.Id).ToList();
            model.ShoppingCarts = db.ShoppingCarts.Where(x => x.Status == false).OrderByDescending(x => x.Say).Take(3).ToList();



            //int a =from x in db.ShoppingCarts.Where(x=>x.Status==false&&x.ProductId==x.Say).Sum()

            //var deyer9 = db.Products.Where(x => x.Status == true).Min(x => x.SatisQiymeti).ToString();
            List<Product> data = new List<Product>();


            if (CateId3 != null)
            {
                model.products = db.Products.Where(x => x.Status == true && x.ProductCategoryaId==CateId3).ToList();

            }
            else if (CateId3 == null)
            {
                model.products = db.Products.Where(x => x.Status == true).ToList();

            }

           

            if (CarId != null)
            {


                model.ProductsFil = db.Products.Where(x => x.CarId == CarId).ToList();
                
                

            }

            else if(CarId == null)
            {
                model.ProductsFil = db.Products.OrderByDescending(x => x.Id).Take(9).ToList();
            }

            if (CateId!=null)
            {
                model.ProductCate = db.Products.Where(x => x.ProductCategoryaId == CateId).ToList();
            }

            else if (CateId == null)
            {
                model.ProductCate = db.Products.OrderByDescending(x => x.Id).Take(6).ToList();

            }

            if (CateId2 != null)
            {
                model.ProductYeniGələn = db.Products.Where(x => x.ProductCategoryaId==CateId2).ToList();
            }

            else if (CateId2==null)
            {
                model.ProductYeniGələn = db.Products.OrderByDescending(x => x.Id).Take(12).ToList();

            }

            if (NewsId != null)
            {
                model.News = db.News.Where( x => x.NewsCategoriesId == NewsId && x.Status==true).ToList();
            }

            else if (NewsId == null)
            {
                model.News = db.News.Where(x => x.Status==true ).Take(6).ToList();
            }

           

            
           
            return View(model);
        }


    }
}