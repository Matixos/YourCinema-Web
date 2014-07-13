using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Globalization;
using System.Threading;
using Kino.Business.Services;

namespace Kino.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                "Default", // Route name
                "{controller}/{action}/{id}", // URL with parameters
                new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
            );

        }

        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }

        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {
            if (HttpContext.Current.Session != null)
            {
                if (Session["culturechangedbeforelogin"] != null && Session["culturechangedbeforelogin"].ToString() == "true" && User.Identity.IsAuthenticated)
                {
                    KinoService.SetUserCulture(User.Identity.Name, this.Session["Culture"].ToString());
                    Session["culturechangedbeforelogin"] = "false";
                }
                string userculture = KinoService.GetUserCulture(User.Identity.Name);
                CultureInfo ci = null;
                if (userculture != null)
                {
                    ci = new CultureInfo(userculture);
                }
                if (ci == null)
                {
                    ci = (CultureInfo)this.Session["Culture"];
                }
                if (ci == null)
                {
                    string langName = "pl";

                    if (HttpContext.Current.Request.UserLanguages != null && HttpContext.Current.Request.UserLanguages.Length != 0)
                    {
                        langName = HttpContext.Current.Request.UserLanguages[0].Substring(0, 2);
                    }
                    ci = new CultureInfo(langName);
                    this.Session["Culture"] = ci;
                }
                Thread.CurrentThread.CurrentUICulture = ci;
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(ci.Name);
            }
        }
    }
}