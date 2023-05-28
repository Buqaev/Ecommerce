using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlisVeris.Models
{
    public class SatisDto
    {
        public User user { get; set; }
        public Product product { get; set; }
        public ShoppingCart shoppingCart { get; set; }
        public List<ProductReview> productReviews { get; set; }

    }
}