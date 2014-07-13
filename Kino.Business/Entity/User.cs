using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace Kino.Business.Entity
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string PESEL { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public string Address { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public string Culture { get; set; }

        public String ActiveToken { get; set; }

        public int Points { get; set; }

        public int ReservationCnt { get; set; }

        public bool IsUser { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime LastActivity { get; set; }
    }
}