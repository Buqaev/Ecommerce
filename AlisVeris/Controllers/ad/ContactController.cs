using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.ad
{
    public class ContactController : Controller
    {
        // GET: Contact
        TicaretEntities db = new TicaretEntities();
        public ActionResult Index()
        {
            List<Contact> contacts = db.Contacts.ToList();

            return View(contacts);
        }

        public ActionResult Delete(int Id)
        {
            Contact contact = db.Contacts.FirstOrDefault(x => x.Id == Id);
            db.Contacts.Remove(contact);

            db.SaveChanges();

            return RedirectToAction("Index");

        }
    }
}