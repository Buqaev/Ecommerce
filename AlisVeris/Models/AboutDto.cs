using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AlisVeris.Models
{
    public class AboutDto
    {
        public List<About> Abouts { get; set; }
        public List<Personnel> Personnels { get; set; }
        public List<Contact> Contacts { get; set; }

    }
}