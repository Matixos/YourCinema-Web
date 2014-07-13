using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kino.Web.Common;
using Kino.Business.Common;
using System.Web.Security;
using MvcContrib.UI.Grid;
using Kino.Business.Entity;
using Kino.Business.Services;
using Kino.Web.Models;

namespace Kino.Web.Controllers
{
    public class AdminController : Controller
    {
        //
        // GET: /Admin/

        [Authorize]
        public ActionResult Index()
        {
            if(!Roles.IsUserInRole(Global.Consts.Administrator)) 
            {
                return RedirectToAction("Index", "Home");
            }

            return View();
        }

        [Authorize]
        [HttpGet]
        public ActionResult UsersList(GridSortOptions gridSortOptions, int? page, bool? loopback)
        {
            if (!Roles.IsUserInRole(Global.Consts.Administrator))
            {
                return RedirectToAction("Index", "Home");
            }

            List<User> users = KinoService.GetFullUsersWithoutWorkers();

            IQueryable<UserSmallModel> viewModel = users.Select(r => new UserSmallModel()
            {
                Id = r.UserId,
                PESEL = r.PESEL,
                Name = r.Name + " " + r.Surname,
                Email = r.Email,
                Culture = r.Culture,
                Points = r.Points,
                ReservationCnt = r.ReservationCnt
            }).AsQueryable();

            var pagedViewModel = new PagedViewModel<UserSmallModel>
            {
                ViewData = ViewData,
                Query = viewModel,
                GridSortOptions = gridSortOptions,
                DefaultSortColumn = "Name",
                Page = page,
                PageSize = 10
            }.Setup();

            return View(pagedViewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult ShowUser(String pesel)
        {
            if (!Roles.IsUserInRole(Global.Consts.Administrator))
            {
                return RedirectToAction("Index", "Home");
            }

            User user = KinoService.GetUser(pesel);

            return View(user);
        }

        [Authorize]
        [HttpGet]
        public ActionResult RemoveUser(String pesel)
        {
            if (!Roles.IsUserInRole(Global.Consts.Administrator))
            {
                return RedirectToAction("Index", "Home");
            }

            KinoService.DeleteUser(pesel);

            return RedirectToAction("UsersList");
        }

        [Authorize]
        [HttpGet]
        public ActionResult RoomsList(GridSortOptions gridSortOptions, int? page, bool? loopback)
        {
            if (!Roles.IsUserInRole(Global.Consts.Administrator))
            {
                return RedirectToAction("Index", "Home");
            }

            List<Room> rooms = KinoService.GetRooms();

            IQueryable<RoomModel> viewModel = rooms.Select(r => new RoomModel()
            {
                RoomNumber = r.RoomNumber,
                Seats = r.Seats,
                Rows = r.Rows,
                Cols = r.Cols
            }).AsQueryable();

            var pagedViewModel = new PagedViewModel<RoomModel>
            {
                ViewData = ViewData,
                Query = viewModel,
                GridSortOptions = gridSortOptions,
                DefaultSortColumn = "RoomNumber",
                Page = page,
                PageSize = 10
            }.Setup();

            return View(pagedViewModel);
        }

        [Authorize]
        [HttpGet]
        public ActionResult FilmsList(GridSortOptions gridSortOptions, int? page, bool? loopback)
        {
            if (!Roles.IsUserInRole(Global.Consts.Administrator))
            {
                return RedirectToAction("Index", "Home");
            }

            List<Film> films = KinoService.GetFilms();

            IQueryable<FilmModel> viewModel = films.Select(f => new FilmModel()
            {
                Title = f.Title,
                Genre = f.Genre,
                Director = f.Director,
                Description = f.Description,
                Year = f.Year
            }).AsQueryable();

            var pagedViewModel = new PagedViewModel<FilmModel>
            {
                ViewData = ViewData,
                Query = viewModel,
                GridSortOptions = gridSortOptions,
                DefaultSortColumn = "Title",
                Page = page,
                PageSize = 10
            }.Setup();

            return View(pagedViewModel);
        }
    }
}
