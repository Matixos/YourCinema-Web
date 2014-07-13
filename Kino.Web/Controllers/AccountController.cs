using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Web.Security;
using Kino.Web.Models;
using Kino.Business.Services;
using Kino.Business.Entity;
using System.Diagnostics;
using System.Net.Mail;
using MvcContrib.UI.Grid;
using Kino.Web.Common;

namespace Kino.Web.Controllers
{
    public class AccountController : Controller
    {

        //
        // GET: /Account/LogOn

        public ActionResult LogOn()
        {
            return View();
        }

        //
        // POST: /Account/LogOn

        [HttpPost]
        public ActionResult LogOn(LogOnModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                switch (KinoService.CheckUser(model.PESEL, model.Password))
                {
                    case 1: 
                        ModelState.AddModelError("", Resources.UIMessage.LogOn_UserDontExist);
                        break;
                    case 2: 
                        ModelState.AddModelError("", Resources.UIMessage.LogOn_UserIsntAccepted);
                        break;
                    case 3: 
                        ModelState.AddModelError("", Resources.UIMessage.LogOn_IncorrectFields);
                        break;
                    default: 
                        FormsAuthentication.SetAuthCookie(model.PESEL, model.RememberMe);
                        UserDataManager.LoadUserId(model.PESEL);
                        UserDataManager.LoadUserName(model.PESEL);
                        return RedirectToAction("Index", "Home");
                }
            }
            return View(model);
        }

        //
        // GET: /Account/LogOff

        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();
            UserDataManager.ClearUserId();
            UserDataManager.ClearUserName();

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/Register

        public ActionResult Register()
        {
            return View();
        }

        //
        // POST: /Account/Register

        [HttpPost]
        public ActionResult Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                MembershipCreateStatus createStatus;
                MembershipUser membUser = Membership.CreateUser(model.PESEL, model.Password, model.Email, null, null, false, null, out createStatus);

                if (createStatus == MembershipCreateStatus.Success)
                {
                    String address = model.Address + ", " + model.Postcode + " " + model.City;

                    User u = KinoService.CreateUser(model.Name, model.Surname, model.PESEL, address, model.Email, 
                        membUser.CreationDate);

                    if (model.Phone != null && !model.Phone.Equals(""))
                        KinoService.setUserPhone(model.PESEL, model.Phone);

                    MailingService.SendConfirmationEmail(u);

                    return RedirectToAction("RegistrationConfirm", new { fromReg=true });
                }
                else
                {
                    ModelState.AddModelError("", ErrorCodeToString(createStatus));
                }
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult RegistrationConfirm(bool fromReg)
        {
            if(!fromReg)
                return RedirectToAction("Index", "Home");

            return View();
        }

        /// <summary>
        /// Verifies if the account of the user with specified id can be activated.
        /// </summary>
        /// <param name="token">Activate Token</param>
        /// <returns></returns>
        /// 
        [HttpGet]
        public ActionResult Verify(string token)
        {
            ViewBag.ShowMenu = false;
            User user = KinoService.GetUserByToken(token);

            bool userExists = user != null;

            if (userExists)
            {
                MembershipUser memberUser = Membership.GetUser(user.PESEL);
                memberUser.IsApproved = true;
                Membership.UpdateUser(memberUser);

                Roles.AddUserToRole(user.PESEL, "User");

                KinoService.NullTokenUser(user.PESEL);

                FormsAuthentication.SetAuthCookie(user.PESEL, false);
            }

            return RedirectToAction("Index", "Home");
        }

        //
        // GET: /Account/ChangePassword

        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }

        //
        // POST: /Account/ChangePassword

        [Authorize]
        [HttpPost]
        public ActionResult ChangePassword(ChangePasswordModel model)
        {
            /*if (ModelState.IsValid)
            {

                // ChangePassword will throw an exception rather
                // than return false in certain failure scenarios.
                bool changePasswordSucceeded;
                try
                {
                    MembershipUser currentUser = Membership.GetUser(User.Identity.Name, true );  // is user online
                    changePasswordSucceeded = currentUser.ChangePassword(model.OldPassword, model.NewPassword);
                }
                catch (Exception)
                {
                    changePasswordSucceeded = false;
                }

                if (changePasswordSucceeded)
                {
                    return RedirectToAction("ChangePasswordSuccess");
                }
                else
                {
                    ModelState.AddModelError("", "The current password is incorrect or the new password is invalid.");
                }
            }*/

            // If we got this far, something failed, redisplay form
            return View(model);
        }

        //
        // GET: /Account/ChangePasswordSuccess

        public ActionResult ChangePasswordSuccess()
        {
            return View();
        }

        public ActionResult ShowReserwations(GridSortOptions gridSortOptions, int? page, bool? loopback)
        {
            List<Reservation> res = KinoService.GetReservations(UserDataManager.UserId);

            IQueryable<ReservationModel> viewModel = res.Select(r => new ReservationModel()
            {
                ReservationId = r.ReservationId,
                Price = r.Price,
                Discount = r.Discount,
                Finished = r.Finished
            }).AsQueryable();

            var pagedViewModel = new PagedViewModel<ReservationModel>
            {
                ViewData = ViewData,
                Query = viewModel,
                GridSortOptions = gridSortOptions,
                DefaultSortColumn = "ReservationId",
                Page = page,
                PageSize = 10
            }.Setup();

            return View(pagedViewModel);
        }

        #region Status Codes
        private static string ErrorCodeToString(MembershipCreateStatus createStatus)
        {
            // See http://go.microsoft.com/fwlink/?LinkID=177550 for
            // a full list of status codes.
            switch (createStatus)
            {
                case MembershipCreateStatus.DuplicateUserName:
                    return "User name already exists. Please enter a different user name.";

                case MembershipCreateStatus.DuplicateEmail:
                    return "A user name for that e-mail address already exists. Please enter a different e-mail address.";

                case MembershipCreateStatus.InvalidPassword:
                    return "The password provided is invalid. Please enter a valid password value.";

                case MembershipCreateStatus.InvalidEmail:
                    return "The e-mail address provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidAnswer:
                    return "The password retrieval answer provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidQuestion:
                    return "The password retrieval question provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.InvalidUserName:
                    return "The user name provided is invalid. Please check the value and try again.";

                case MembershipCreateStatus.ProviderError:
                    return "The authentication provider returned an error. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                case MembershipCreateStatus.UserRejected:
                    return "The user creation request has been canceled. Please verify your entry and try again. If the problem persists, please contact your system administrator.";

                default:
                    return "An unknown error occurred. Please verify your entry and try again. If the problem persists, please contact your system administrator.";
            }
        }
        #endregion
    }
}
