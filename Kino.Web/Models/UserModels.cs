using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Kino.Web.Models
{
    public class UserSmallModel
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }

        [Display(ResourceType = typeof(Resources.Model), Name = "User_PESEL")]
        [StringLength(256, MinimumLength = 3)]
        public string PESEL { get; set; }

        [Display(ResourceType = typeof(Resources.Model), Name = "User_Name")]
        [StringLength(256, MinimumLength = 3)]
        public string Name { get; set; }

        [Display(ResourceType = typeof(Resources.Model), Name = "User_Email")]
        [StringLength(256, MinimumLength = 5)]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Resources.Model), Name = "User_Culture")]
        public string Culture { get; set; }

        [Display(ResourceType = typeof(Resources.Model), Name = "User_Points")]
        public int Points { get; set; }

        [Display(ResourceType = typeof(Resources.Model), Name = "User_ReservationCnt")]
        [StringLength(256, MinimumLength = 3)]
        public int ReservationCnt { get; set; }
    }
}