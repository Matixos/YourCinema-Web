using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Globalization;
using Kino.Business.Services;

namespace Kino.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            //ViewBag.Message = "Witaj na stronie kina \"Widz\" !";
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult ChangeCulture(string lang, string returnUrl)
        {
            if (User.Identity.Name == "")
            {
                Session["culturechangedbeforelogin"] = "true";
            }
            else
            {
                KinoService.SetUserCulture(User.Identity.Name, lang);
            }

            Session["Culture"] = new CultureInfo(lang);
            return Redirect(returnUrl);
        }
    }
}
