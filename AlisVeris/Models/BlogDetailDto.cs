using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlisVeris.Models
{
    public class BlogDetailDto
    {
        public News New { get; set; }
        public List<BlogComment> blogComments { get; set; }

        public User User { get; set; }



        public News News2 { get; set; }
        public List<News> News3 { get; set; }
        public List<BlogComment> BlogComments { get; set; }
        public BlogComment BlogComment { get; set; }


        public List<News> News { get; set; }
        public List<NewsCategory> NewsCategories { get; set; }
        //public List<DoctorCategory> doctorCategories { get; set; }

        public List<Cloud> Clouds { get; set; }
        public List<Teg> Tegs { get; set; }
        public List<Teg> Tegs2 { get; set; }
        public List<BlogComment> blogComment { get; set; }
    }
}