using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Filters;
using AlisVeris.Models;

namespace AlisVeris.Controllers.us
{
  
    public class ProductPageController : Controller
    {
        // GET: ProductPage
        TicaretEntities db = new TicaretEntities();

        
        public ActionResult Index(NewsCategory blogCategory, int? CatId, int? TagId, int? page, string p,int? Categori,int? Marka,int? Mehsul, string min, string max)
        {
            ProductPageDto model = new ProductPageDto();

            model.Products = db.Products.Where(x => x.Status == true).ToList();


            




            if (page == null)
            {
                page = 1;
            }
            int skip = ((int)page - 1) * 2;

            List<Product> data = new List<Product>();
          
            //data = db.Products.Where(w => 
            //   (CatId == null ? true : w.ProductCategoryaId == CatId)
            //&& (Marka == null ? true : w.CarId == (Marka ?? 0)
           
            //)).ToList();

            if (CatId != null)
            {
                data = db.Products.Where(w => w.ProductCategoryaId == CatId && w.Status == true).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

            }
            else if (TagId != null)
            {

                List<int> nws = db.Clouds.Where(w => w.TegId == TagId).Select(s => s.NewsId).ToList();
                data = db.Products.Where(w => nws.Contains(w.Id)).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

            }
            else if (p != null && p.Length > 0)
            {
                data = db.Products.Where(x => x.Ad.Contains(p)).OrderByDescending(o => o.Id).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();
            }
            else
            {
                data = db.Products.Where(x => x.Status == true).OrderByDescending(o => o.Id).ToList();

                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

                p = null;

            }
          

            if (Marka != null)
            {
                //data = db.Cars.Where(w => w.CarMarkalId == MarkaId).ToList();
                if (Marka != null && Mehsul != null)
                {
                    //data = db.Cars.Where(w => w.Id == MarkaId &&w.Id==ModelId).ToList();

                    data = db.Products.Where(w => w.Status == true && w.Id == Mehsul).ToList();
                }

                if (Marka != null && Mehsul != null && Categori !=null)
                {
                    //data = db.Cars.Where(w => w.Id == MarkaId &&w.Id==ModelId).ToList();

                    data = db.Products.Where(w => w.Status == true && w.Id == Mehsul && w.ProductCategoryaId==Categori).ToList();
                }

                else
                {
                    data = db.Products.Where(w => w.CarId == Marka && w.Status == true).ToList();
                }
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

            }
            else if (Mehsul != null)
            {

                //List<int> nws = db.Clouds.Where(w => w.TeqId == TagId).Select(s => s.XeberId).ToList();
                data = db.Products.Where(w => w.Id == Mehsul && w.CarId == Marka).ToList();

                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();
            }

            else if (p != null && p.Length > 0)
            {
                data = db.Products.Where(x => x.Ad.Contains(p) && x.Status == true).OrderByDescending(o => o.Id).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();
            }

            if (max != null && min != null)
            {
                // int cem = int.Parse(max) - int.Parse(min);
                int balaca = int.Parse(min);
                int boyuk = int.Parse(max);
                data = db.Products.Where(x => x.Status == true && x.SatisQiymeti < boyuk && x.SatisQiymeti > balaca).ToList();

                //ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                //ViewBag.Page = page;
                //data = data.Skip(skip).Take(2).ToList();
            }

            model.Products = data;
            model.ProductCategories = db.ProductCategories.Where(x => x.Status == true).ToList();
            //model.doctorCategories = db.DoctorCategories.Where(x => x.Status == true).ToList();
            //model.Tegs = db.Tegs.Where(x => x.Status == true).ToList();
            model.Products2 = db.Products.Where(x => x.Status == true).OrderByDescending(o => o.Id).Take(5).ToList();
            //model.BlogComments = db.BlogComments.OrderByDescending(o => o.Id).Take(3).ToList();


            model.Products3 = db.Products.Where(x => x.Status == true).ToList();
            model.Cars = db.Cars.Where(x => x.Status == true).ToList();

            ViewBag.Axtaris = p;
            ViewBag.CatId = CatId;
            ViewBag.TagId = TagId;


            return View(model);
        }

        [HttpGet]
        public ActionResult ProductDetail(int Id)
        {
            ProductDetailDto model = new ProductDetailDto();

            model.Products = db.Products.Where(x => x.Status == true && x.Id==Id).ToList();
            model.Product = db.Products.FirstOrDefault(x => x.Id == Id);
            //model.shoppingCart = db.ShoppingCarts.FirstOrDefault(x => x.Id == Id);
            model.Carusels = db.Carusels.Where(x => x.Status == true && x.ProductId==Id).ToList();
            model.productReviews = db.ProductReviews.Where(x => x.Status == true && x.ProductId == Id).ToList();
            model.Products2 = db.Products.Where(x => x.Status == true).OrderByDescending(x => x.Id).Take(6).ToList();

            //ulduzlarin ortalamasi
            int ComSay = db.ProductReviews.Where(x => x.ProductId == Id).Count();
            if (ComSay >= 1)
            {
                int? deyer = (from x in db.ProductReviews.Where(w => w.ProductId == Id) select x.Ulduzsayi).Sum();
                double? orta = deyer / ComSay;
                ViewBag.orta = orta;
            }
           

            return View(model);
        }

        
        public ActionResult Satis( ShoppingCart s,int id)
        {
            SatisDto model = new SatisDto();
            string Id = Session["Id"]?.ToString();
            int? ID = int.Parse(Id);
            model.user = db.Users.SingleOrDefault(x => x.Id == ID);
            s.User = db.Users.SingleOrDefault(x => x.Id == ID);

            s.Status = true;





            



           
            s.Product = db.Products.SingleOrDefault(t => t.Id == id);      

            s.Qiymet = s.Product.SatisQiymeti;

           
            s.UmumiMebleg = s.Product.SatisQiymeti * s.Say;


            db.ShoppingCarts.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");

            
        }

        //[HttpPost]
        //public ActionResult SatisEt()
        //{


        //    return View();

        //}

        public PartialViewResult Sebet(/*int? Id*/)
        {
            //ProductPageDto model = new ProductPageDto();
            //model.shoppingCarts = db.ShoppingCarts.ToList();
            string Id = Session["Id"]?.ToString();
            if (Id != null)
            {
                int? ID = int.Parse(Id);
                ViewBag.mehsul = db.ShoppingCarts.Where(x => x.UserId == ID && x.Status==true).ToList();
                List<ShoppingCart> shoppingCarts = db.ShoppingCarts.Where(x => x.UserId == ID && x.Status==true).ToList();
                ShoppingCart s = db.ShoppingCarts.FirstOrDefault(x => x.UserId == ID && x.Status == true);

                
                    if (shoppingCarts.Count() != 0 && s.Status == true)
                {
                    ViewBag.umumimebleg = (from x in db.ShoppingCarts.Where(x => x.UserId == ID && x.Status == true) select x.UmumiMebleg).Sum();
                    ViewBag.cesidSayi = (from x in db.ShoppingCarts.Where(x => x.UserId == ID && x.Status == true) select x.Say).Sum();
                    ViewBag.mehsulSayi = db.ShoppingCarts.Where(x => x.UserId == ID && x.Status == true).Count();
                }
            }

            //if (ID!=null)
            //{


            //}
            //else if (ID == 0)
            //{

            //    return PartialView();
            //}

            return PartialView(/*"~/Views/Shared/_PanelLayout.cshtml"*/);
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

        [HttpGet]
        public ActionResult CixarisEt(Checkout c/*, int Id*/)
        {
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);

            c.ShoppingCart = db.ShoppingCarts.FirstOrDefault(t => t.Id == ID);      //olmasa c date ele




            return View(c);
        }
        public static List<ShoppingCart> item { get; set; }

        [HttpPost]
        public ActionResult Cixaris(Checkout s, Order o)
        {

            Random rnd = new Random();
            string[] deyerler = { "A", "B", "C", "D" };
            int d1, d2, d3;
            d1 = rnd.Next(0, 4);                                    //burada Random Kargo kodu yaratdim
            d2 = rnd.Next(0, 4);
            d3 = rnd.Next(0, 4);
            int s1, s2, s3;
            s1 = rnd.Next(100, 1000);
            s2 = rnd.Next(10, 99);
            s3 = rnd.Next(10, 99);

            string kod = s1.ToString() + deyerler[d1] + s2 + deyerler[d2] + s3 + deyerler[d3];
            o.FakduraKodu = kod;
            o.Status = true;
            o.Tarix = DateTime.Now;
            
            db.Orders.Add(o);
            db.SaveChanges();


            int satir = 0;
            SatisDto model = new SatisDto();
            string Id = Session["Id"].ToString();
            var ID = int.Parse(Id);
            User u = db.Users.SingleOrDefault(x => x.Id == ID);
            //s.User = db.Users.SingleOrDefault(x => x.Id == ID);
            o.UserId = ID;
            List<ShoppingCart> carts = new List<ShoppingCart>();

            carts = db.ShoppingCarts.Where(x => x.UserId == ID && x.Status == true ).ToList();
            
            var data = db.ShoppingCarts.Where(x => x.UserId == ID && x.Status==true).ToList();

            
            foreach (var x in data)
            {
                var satis = new Checkout
                {
                    
                    
                    ShoppingCartsId = data[satir].Id,
                    UserId = data[satir].UserId,
                    OrderId=o.Id,
                    CatdirilmaAdres=s.CatdirilmaAdres,
                    CatdirilmaSeher=s.CatdirilmaSeher,
                    CatdirilmaSeheri=s.CatdirilmaSeheri,
                    
                };
                Product products =db.Products.SingleOrDefault(z=>z.Id==x.ProductId);
                
               
                int a = (from y in db.ShoppingCarts.Where(j => j.Product.Id == products.Id &&j.UserId==ID && j.Status==true) select y.Say).Sum();
                products.StokSayi = products.StokSayi - a;


                db.Checkouts.Add(satis);
                //data.Select(t => t.Status == false);

                
                db.SaveChanges();
                satir++;

            }

            List<ShoppingCart> shoppingCarts = db.ShoppingCarts.Where(x => x.UserId == ID).ToList();

            foreach (var x in shoppingCarts)
            {
                x.Status = false;
                db.SaveChanges();
            }

            //db.ShoppingCarts.Select(x=>x.Status==false);
           
            db.SaveChanges();


            return RedirectToAction("Index");
            



        }


  

        [HttpPost]
        public ActionResult YeniComment(ProductReview c, int Id, int rating)   //saba prtojenin vidyosuna bax
        {
            CommentDto data = new CommentDto();
            String id = Session["Id"].ToString();  //olmasa burani userId ver
            var ID = int.Parse(id);
            //User user = db.Users.SingleOrDefault(x => x.Id == ID);
            data.User = db.Users.SingleOrDefault(x => x.Id == ID);
            // data.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Id);
            c.Tarix = DateTime.Now;
            c.Status = true;
            c.Ulduzsayi = rating;
            c.Product = db.Products.SingleOrDefault(t => t.Id == Id);      //olmasa c date ele

            c.User = db.Users.SingleOrDefault(x => x.Id == ID);

            db.ProductReviews.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

     
    }
}