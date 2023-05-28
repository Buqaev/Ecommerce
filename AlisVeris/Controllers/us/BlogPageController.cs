using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AlisVeris.Models;
namespace AlisVeris.Controllers.us
{
    public class BlogPageController : Controller
    {
        // GET: BlogPage
        TicaretEntities db = new TicaretEntities();

        public ActionResult Index(NewsCategory blogCategory, int? CatId, int? TagId, int? page, string p)
        {
            BlogPageDto model = new BlogPageDto();
            model.News = db.News.Where(x => x.Status == true).ToList();




            if (page == null)
            {
                page = 1;
            }
            int skip = ((int)page - 1) * 2;

            List<News> data = new List<News>();


            if (CatId != null)
            {
                data = db.News.Where(w => w.NewsCategoriesId == CatId && w.Status==true).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

            }
            else if (TagId != null)
            {

                List<int> nws = db.Clouds.Where(w => w.TegId == TagId).Select(s => s.NewsId).ToList();
                data = db.News.Where(w => nws.Contains(w.Id)).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

            }
            else if (p != null && p.Length > 0)
            {
                data = db.News.Where(x => x.Basliq.Contains(p)).OrderByDescending(o => o.Id).ToList();
                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();
            }
            else
            {
                data = db.News.Where(x=>x.Status==true).OrderByDescending(o => o.Id).ToList();

                ViewBag.TotalPage = Math.Ceiling(data.Count / 2.00);
                ViewBag.Page = page;
                data = data.Skip(skip).Take(2).ToList();

                p = null;

            }

            model.News = data;
            model.NewsCategories = db.NewsCategories.Where(x => x.Status == true).ToList();
            //model.doctorCategories = db.DoctorCategories.Where(x => x.Status == true).ToList();
            model.Tegs = db.Tegs.Where(x => x.Status == true).ToList();
            model.News2 = db.News.Where(x=>x.Status==true).OrderByDescending(o => o.Id).Take(3).ToList();
            model.BlogComments = db.BlogComments.OrderByDescending(o => o.Id).Take(3).ToList();
            
            ViewBag.Axtaris = p;
            ViewBag.CatId = CatId;
            ViewBag.TagId = TagId;


            return View(model);

        }



        public ActionResult BlogDetail(int Id, int? CatId, int? TagId)
        {
            BlogDetailDto data = new BlogDetailDto();

            data.New = db.News.FirstOrDefault(x => x.Id == Id);



            //model.blogComments = db.BlogComments.Where(x => x.Id == Id).ToList();
            //model.Blog = db.Blogs.FirstOrDefault(x => x.Id == Id);

            //model.blogComments = db.BlogComments.Where(x => x.BlogId == Id).ToList();




            if (CatId != null)
            {
                data.News = db.News.Where(w => w.NewsCategoriesId == CatId).ToList();
            }
            else if (TagId != null)
            {

                List<int> nws = db.Clouds.Where(w => w.TegId == TagId).Select(s => s.NewsId).ToList();
                data.News = db.News.Where(w => nws.Contains(w.Id)).ToList();

            }
            else
            {
                data.News = db.News.ToList();
            }


            //data.Blog2 = db.Blogs.FirstOrDefault(x => x.Id == Id);

            data.BlogComments = db.BlogComments.Where(x => x.NewsId == Id).ToList();
            data.blogComments = db.BlogComments.OrderByDescending(x => x.Id).Take(3).ToList();
            var deyer = db.BlogComments.Where(x => x.NewsId == Id).Count().ToString();
            ViewBag.ReviewSay = deyer;





            data.NewsCategories = db.NewsCategories.Where(x => x.Status == true).ToList();
            data.Tegs = db.Tegs.Where(x => x.Status == true).ToList();
            data.Tegs2 = db.Tegs.Where(x => x.Id==Id).ToList();

            data.News3 = db.News.Where(x => x.Status == true).OrderByDescending(x => x.Id).Take(3).ToList();
            return View(data);


        }


        [HttpPost]
        public ActionResult BlogComment(BlogComment c, int Id)   //saba prtojenin vidyosuna bax
        {
            BlogCommentDto data = new BlogCommentDto();
            String id = Session["Id"].ToString();  //olmasa burani userId ver
            var ID = int.Parse(id);
            //User user = db.Users.SingleOrDefault(x => x.Id == ID);
            data.User = db.Users.SingleOrDefault(x => x.Id == ID);
            // data.Doctor = db.Doctors.SingleOrDefault(x => x.Id == Id);
            c.Tarix = DateTime.Now;
            c.Status = true;
           
            c.News = db.News.SingleOrDefault(t => t.Id == Id);      //olmasa c date ele

            c.User = db.Users.SingleOrDefault(x => x.Id == ID);

            db.BlogComments.Add(c);
            db.SaveChanges();

            return RedirectToAction("Index");
        }
    }

    
}