using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AlisVeris.Models
{
    public class HomeDto
    {
        public List<Product> products { get; set; }
        public List<Product> Products2 { get; set; }
        public List<Product> ProductsFil { get; set; }
        public List<Product> ProductCate { get; set; }
        public List<Product> ProductYeniGələn { get; set; }
        public List<ProductReview> UlduzQiymet { get; set; }
        public ProductReview Say { get; set; }
        public Product MinQiymet { get; set; }
        public Product MinQiymet2 { get; set; }
        public Product MinQiymet3 { get; set; }
        public List<ProductCategory> categories { get; set; }
        public List<Car> cars { get; set; }
        public List<Car> cars2 { get; set; }
        public List<ProductCategory> categories2 { get; set; }
        public List<ProductCategory> Categories3 { get; set; }
        public List<News> News { get; set; }
        public List<NewsCategory> NewsCategories { get; set; }
        public List<Checkout> Checkouts { get; set; }
        public List<ShoppingCart> ShoppingCarts { get; set; }
    }
}