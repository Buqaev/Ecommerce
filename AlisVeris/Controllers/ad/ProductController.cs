using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.ad
{
    public class ProductController : Controller
    {
        // GET: Product
        TicaretEntities db = new TicaretEntities();
        public ActionResult Index()
        {
            List<Product> products = db.Products.Where(x => x.Status == true).ToList();

            return View(products);
        }

        [HttpGet]
        public ActionResult CreateProduct()
        {
            ProDto model = new ProDto();
            List<Product> products = db.Products.ToList();
            //List<ProductCategory> categories = db.ProductCategories.Where(x => x.Status == true).ToList();
            model.Cars = db.Cars.Where(x => x.Status == true).ToList();
            model.Categories= db.ProductCategories.Where(x => x.Status == true).ToList();
            return View(model);
        }

        [HttpPost]
        public ActionResult Create(Product product, HttpPostedFileBase Sekil)
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
            product.MehsulKod = kod;

            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                product.Sekil = Path.GetFileName(Sekil.FileName);

            }
            product.Tarix = DateTime.Now;
            product.Status = true;
            db.Products.Add(product);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult ProductUpdate(int Id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == Id);
            ViewBag.cate = db.ProductCategories.Where(x => x.Status == true).ToList();
            ViewBag.car = db.Cars.Where(x => x.Status == true).ToList();
            return View(product);
        }

        public ActionResult Update(Product product, HttpPostedFileBase Sekil)
        {
            Product n = db.Products.FirstOrDefault(x => x.Id == product.Id);
            n.Ad = product.Ad;
            n.Acixlama = product.Acixlama;
            n.Description = product.Description;
            n.Material = product.Material;
            n.EnerjiTipi = product.EnerjiTipi;
            n.Voltaj = product.Voltaj;
            n.Ceki = product.Ceki;
            n.Eni = product.Eni;
            n.Uzunluq = product.Uzunluq;
            n.AlisQiymeti = product.AlisQiymeti;
            n.SatisQiymeti = product.SatisQiymeti;
            n.StokSayi = product.StokSayi;
            n.Reng = product.Reng;
            n.Tarix = DateTime.Now;
            n.ProductCategoryaId = product.ProductCategoryaId;
            n.CarId = product.CarId;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                n.Sekil = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delate(int Id)
        {
            Product product = db.Products.FirstOrDefault(x => x.Id == Id);
            product.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}