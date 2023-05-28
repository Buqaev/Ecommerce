using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;

namespace AlisVeris.Controllers.ad
{
    public class CarController : Controller
    {
        // GET: Car
        TicaretEntities db = new TicaretEntities();

        public ActionResult Index()
        {
            List<Car> cars = db.Cars.Where(x => x.Status == true).ToList();

            return View(cars);
        }
        [HttpGet]
        public ActionResult CreateCar()
        {
            List<Car> cars = db.Cars.Where(x=>x.Status==true).ToList();
            
            return View(cars);
        }

        [HttpPost]
        public ActionResult Create(Car car)
        {


            car.Status = true;
            db.Cars.Add(car);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult CarUpdate(int Id)
        {
            Car cars = db.Cars.FirstOrDefault(x => x.Id == Id);
           
            return View(cars);
        }

        public ActionResult Update(Car cars, HttpPostedFileBase Sekil)
        {
            Car n = db.Cars.FirstOrDefault(x => x.Id == cars.Id);
            n.Marka = cars.Marka;
            n.Model = cars.Model;
            n.MotorNovu = cars.MotorNovu;
            n.il = cars.il;
            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public ActionResult Delate(int Id)
        {
            Car car = db.Cars.FirstOrDefault(x => x.Id == Id);
            car.Status = false;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}