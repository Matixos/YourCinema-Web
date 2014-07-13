using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Kino.Business.Entity
{
    public class FilmShow
    {
        [Key]
        public int Id { get; set; }

        public string Film { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{dd-MM-yyyy}")]
        public DateTime Date { get; set; }
        
        public int Room { get; set; }

        [DataType(DataType.Time)]
        [DisplayFormat(DataFormatString = "{hh:mm}")]
        public DateTime Time { get; set; }
    }
}
