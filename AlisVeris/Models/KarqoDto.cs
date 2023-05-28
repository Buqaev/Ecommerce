using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlisVeris.Models
{
    public class KarqoDto
    {
        public List<ShoppingCart> shoppingCarts { get; set; }
        public List<Checkout> checkouts { get; set; }

    }
}