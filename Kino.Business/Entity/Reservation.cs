using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Kino.Business.Entity
{
    public class Reservation
    {
        [Key]
        public String ReservationId { get; set; }
        
        public float Price { get; set; }

        public float Discount { get; set; }

        public bool Finished { get; set; }

        public int Owner { get; set; }

        public int FilmShow { get; set; }
    }
}