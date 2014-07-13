using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Kino.Business.Entity
{
    class ReservationPlace
    {
        [Key]
        public int Id { get; set; }

        public String Reservation { get; set; }

        public int Place { get; set; }

        public String Row { get; set; }
    }
}
