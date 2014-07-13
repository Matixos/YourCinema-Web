using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Kino.Web.Common;
using Kino.Business.Services;
using Kino.Business.Entity;
using System.Diagnostics;
using Kino.Web.Models;

namespace Kino.Web.Controllers
{
    public class RepertoireController : Controller
    {
        //
        // GET: /Repertoire/

        [HttpGet]
        public ActionResult Index(DateTime? date, bool? loopback)
        {
            ViewBag.Show = false;

            if (date != null && loopback == null)
            {
                ViewBag.Show = true;

                List<string> filmList = KinoService.GetSeanses((DateTime)date);

                List<FilmShowPresentModel> fullRepertoire = new List<FilmShowPresentModel>();

                foreach (string film in filmList)
                {
                    fullRepertoire.Add(new FilmShowPresentModel() { FilmName = film, timesShow = KinoService.GetTimesOfSeans((DateTime)date, film) });
                }

                return View(fullRepertoire);
            }

            return View();
        }

        [Authorize]
        public ActionResult GetTicket(string film, DateTime date, int userId)
        {
            FilmShow filmShow = KinoService.GetFilmShow(film, date.Date);

            User u = KinoService.GetUser(userId);

            KinoService.AddReservation(filmShow.Id, userId, 40, u.Name, u.Surname, filmShow.Film);

            return RedirectToAction("Index");
        }

    }
}
