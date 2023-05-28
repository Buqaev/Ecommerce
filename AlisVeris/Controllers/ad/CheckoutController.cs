using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.ad
{
    public class CheckoutController : Controller
    {
        // GET: Checkout
        TicaretEntities db = new TicaretEntities();

        public ActionResult Index()
        {
            List<Checkout> checkouts = db.Checkouts.ToList();

            return View(checkouts);
        }
    }
}