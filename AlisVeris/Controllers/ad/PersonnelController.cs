using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.ad
{
    public class PersonnelController : Controller
    {
        // GET: Personnel
        TicaretEntities db = new TicaretEntities();
        public ActionResult Index()
        {
            List<Personnel> personnels = db.Personnels.Where(x => x.Status == true).ToList();

            return View(personnels);
        }

        [HttpGet]
        public ActionResult CreatePersonnel()
        {
            List<Personnel> personnels = db.Personnels.ToList();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Personnel personnel, HttpPostedFileBase Sekil)
        {


            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                personnel.Sekil = Path.GetFileName(Sekil.FileName);

            }
            personnel.Status = true;
            db.Personnels.Add(personnel);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult PersonnelUpdate(int Id)
        {
            Personnel personnel = db.Personnels.FirstOrDefault(x => x.Id == Id);

            return View(personnel);
        }

        public ActionResult Update(Personnel personnel, HttpPostedFileBase Sekil)
        {
            Personnel p = db.Personnels.FirstOrDefault(x => x.Id == personnel.Id);
            p.Ad = personnel.Ad;
            p.Soyad = personnel.Soyad;
            p.Veziffe = personnel.Veziffe;
            if (Sekil != null)
            {
                string path = Path.Combine(Server.MapPath("~/Images"), Path.GetFileName(Sekil.FileName));
                Sekil.SaveAs(path);
                p.Sekil = Path.GetFileName(Sekil.FileName);
            }
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delate(int Id)
        {
            Personnel personnel = db.Personnels.FirstOrDefault(x => x.Id == Id);
            personnel.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}