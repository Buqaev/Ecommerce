using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlisVeris.Models
{
    public class CatPageDto
    {
        public List<ProductCategory> ProductCategories { get; set; }
        public List<Product> Products3 { get; set; }
        public List<Product> Products { get; set; }
        public List<Product> Products2 { get; set; }
        public List<Car> Cars { get; set; }

    }
}