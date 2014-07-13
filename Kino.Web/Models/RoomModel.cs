using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kino.Web.Models
{
    public class RoomModel
    {
        public int RoomNumber { get; set; }

        public int Seats { get; set; }

        public int Rows { get; set; }

        public int Cols { get; set; }
    }
}