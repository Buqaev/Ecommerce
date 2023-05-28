using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlisVeris.Models
{
    public class ProductDetailDto
    {
        public List<Product> Products { get; set; }
        public List<Product> Products2 { get; set; }
        public Product Product { get; set; }
        public List<Carusel> Carusels { get; set; }
        public User user { get; set; }
        public ShoppingCart shoppingCart { get; set; }

        public List<ProductReview> productReviews{ get; set; } 

    }
}