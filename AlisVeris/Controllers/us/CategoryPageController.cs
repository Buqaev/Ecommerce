using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.us
{
    public class CategoryPageController : Controller
    {
        // GET: CategoryPage
        TicaretEntities db = new TicaretEntities();

        public ActionResult Index(int? CatId,int? ProId /*,int? Id*/)
        {


            CatPageDto model = new CatPageDto();


            List<Product> data = new List<Product>();
            
            
            model.ProductCategories = db.ProductCategories.Where(x => x.Status == true).ToList();

            model.Products3 = db.Products.Where(x => x.Status == true).ToList();
            model.Products = db.Products.OrderByDescending(x => x.Id).Take(5).ToList();
            model.Products2 = db.Products.OrderByDescending(x => x.Id).Take(10).ToList();
            //model.Products = db.Products.Where(x => x.ProductCategory.Id == Id).ToList();
            if (CatId != null)
            {
                data = db.Products.Where(w => w.ProductCategoryaId == CatId && w.Status == true).ToList();
                model.Products3 = data;

            }


            return View(model);
        }
    }
}