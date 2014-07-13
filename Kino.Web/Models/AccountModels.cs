using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Web.Mvc;
using System.Web.Security;

using Kino.Business.Services;
using Kino.Business.Entity;

namespace Kino.Web.Models
{
    public class ChangePasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "New password")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm new password")]
        [System.Web.Mvc.Compare("NewPassword", ErrorMessage = "The new password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }

    public class LogOnModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "LogOn_Requirence")]
        [Display(ResourceType = typeof(Resources.Model), Name = "LogOn_Pesel")]
        [StringLength(11, ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "LogOn_PeselRestriction", MinimumLength = 11)]
        public string PESEL { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "LogOn_Requirence")]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Model), Name = "LogOn_Password")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Resources.Model), Name = "LogOn_RememberMe")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_Requirence")]
        [Display(ResourceType = typeof(Resources.Model), Name = "Registration_Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_Requirence")]
        [Display(ResourceType = typeof(Resources.Model), Name = "Registration_Surname")]
        public string Surname { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_Requirence")]
        [Display(ResourceType = typeof(Resources.Model), Name = "Registration_PESEL")]
        [StringLength(11, ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_PeselRestriction", MinimumLength = 11)]
        public string PESEL { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_Requirence")]
        [Display(ResourceType = typeof(Resources.Model), Name = "Registration_Address")]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_Requirence")]
        [Display(ResourceType = typeof(Resources.Model), Name = "Registration_Postcode")]
        [RegularExpression(@"^[0-9]{2}-[0-9]{3}$", ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_PostcodeRestriction")]
        public string Postcode { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_Requirence")]
        [Display(ResourceType = typeof(Resources.Model), Name = "Registration_City")]
        public string City { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_Requirence")]
        [StringLength(100, ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_PasswordRestriction", MinimumLength = 3)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Model), Name = "Registration_Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources.Model), Name = "Registration_ConfirmPassword")]
        [System.Web.Mvc.Compare("Password", ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_PasswordMatching")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_Requirence")]
        [DataType(DataType.EmailAddress)]
        [Display(ResourceType = typeof(Resources.Model), Name = "Registration_Email")]
        public string Email { get; set; }

        [DataType(DataType.PhoneNumber)]
        [StringLength(12, ErrorMessageResourceType = typeof(Resources.Model), ErrorMessageResourceName = "Registration_PhoneToLong")]
        [Display(ResourceType = typeof(Resources.Model), Name = "Registration_Phone")]
        public string Phone { get; set; }
    }
}
