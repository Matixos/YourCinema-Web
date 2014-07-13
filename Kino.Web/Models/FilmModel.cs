using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kino.Web.Models
{
    public class FilmModel
    {
        public String Title { get; set; }

        public string Genre { get; set; }

        public string Director { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }
    }
}