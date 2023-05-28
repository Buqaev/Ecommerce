using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlisVeris.Models
{
    public class BlogCommentDto
    {
        public News News { get; set; }
        public User User { get; set; }
        public BlogComment BlogComment { get; set; }
    }
}