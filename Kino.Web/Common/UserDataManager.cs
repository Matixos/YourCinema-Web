using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Kino.Business.Entity;
using Kino.Business.Services;

namespace Kino.Web.Common
{
    public class UserDataManager
    {
        private static string sessionVarName = "userid";
        private static string sessionVarName1 = "userName";

        public static int UserId
        {
            get
            {
                HttpContext httpContext = HttpContext.Current;

                var userId = httpContext.Session[sessionVarName];

                if (userId == null)
                {
                    LoadUserId();
                    userId = httpContext.Session[sessionVarName];
                }

                return userId == null ? 0 : (int)userId;
            }
            set { HttpContext.Current.Session[sessionVarName] = value; }
        }

        public static void LoadUserId()
        {
            LoadUserId(HttpContext.Current.User.Identity.Name);
        }

        public static void LoadUserId(string name)
        {
            User user = KinoService.GetUser(name);

            ClearUserId();

            if (user != null)
                UserId = user.UserId;
        }

        public static void ClearUserId()
        {
            HttpContext.Current.Session.Remove(sessionVarName);
        }


        public static string UserName
        {
            get
            {
                HttpContext httpContext = HttpContext.Current;

                var userName = httpContext.Session[sessionVarName1];

                if (userName == null)
                {
                    LoadUserName();
                    userName = httpContext.Session[sessionVarName1];
                }

                return userName == null ? "" : (String)userName;
            }
            set { HttpContext.Current.Session[sessionVarName1] = value; }
        }

        public static void LoadUserName()
        {
            LoadUserName(HttpContext.Current.User.Identity.Name);
        }

        public static void LoadUserName(string name)
        {
            User user = KinoService.GetUser(name);

            ClearUserName();

            if (user != null)
                UserName = user.Name + " " + user.Surname;
        }

        public static void ClearUserName()
        {
            HttpContext.Current.Session.Remove(sessionVarName1);
        }
    }
}