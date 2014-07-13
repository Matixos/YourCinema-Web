using System;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Kino.Business.Entity
{
    public class Film
    {
        [Key]
        public String Title { get; set; }

        public string Genre { get; set; }
        
        public string Director { get; set; }

        public string Description { get; set; }

        public int Year { get; set; }
    }
}
