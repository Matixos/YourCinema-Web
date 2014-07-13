using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Kino.Business.Entity
{
    class Report
    {
        [Key]
        public int Id { get; set; }

        public String Content { get; set; }

        public int Creator { get; set; }
    }
}
