using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kino.Web.Models
{
    public class FilmShowPresentModel
    {
        public string FilmName { get; set; }

        public List<DateTime> timesShow { get; set; }
    }
}