using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlisVeris.Models
{
    public class CommentDto
    {
        public User User { get; set; }
        public Product Product { get; set; }
        public ProductReview ProductReview { get; set; }

    }
}