using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Kino.Business.Entity
{
    public class Room
    {
        [Key]
        public int RoomNumber { get; set; }

        public int Seats { get; set; }

        public int Rows { get; set; }

        public int Cols { get; set; }
    }
}
