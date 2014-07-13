using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kino.Web.Models
{
    public class ReservationModel
    {
        public string ReservationId { get; set; }

        public float Price { get; set; }

        public float Discount { get; set; }

        public bool Finished { get; set; }
    }
}