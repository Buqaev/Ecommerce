using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.us
{
    public class IstatistikPageController : Controller
    {
        // GET: IstatistikPage

        TicaretEntities db = new TicaretEntities();
        public ActionResult Index()
        {
            List<Product> products = db.Products.Where(x => x.Status == true).OrderByDescending(x => x.Id).Take(5).ToList();

            return View(products);
        }
    }
}