using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;

using Kino.Business.Entity;
using Kino.Business.Dal;
using Kino.Business.Common;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Data.Entity.Infrastructure;
using System.Data;
using System.Globalization;

namespace Kino.Business.Services
{
    /// <summary>
    /// Business logic facade
    /// </summary>
    public static class KinoService
    {
        #region User's actions

        /// <summary>
        /// Gets the existing user.
        /// </summary>
        /// <param name="evaluationId">user's pesel</param>
        /// <returns></returns>
        public static User GetUser(String pesel)
        {
            KinoDb db = new KinoDb();
            User user = (from u in db.Users
                         where u.PESEL == pesel
                         select u).FirstOrDefault();
            return user;
        }

        public static User GetUser(int id)
        {
            KinoDb db = new KinoDb();
            User user = (from u in db.Users
                         where u.UserId == id
                         select u).FirstOrDefault();
            return user;
        }

        public static User GetUserByToken(String token)
        {
            KinoDb db = new KinoDb();
            User user = (from u in db.Users
                         where u.ActiveToken == token
                         select u).FirstOrDefault();
            return user;
        }

        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <returns></returns>
        public static List<User> GetUsers()
        {
            KinoDb db = new KinoDb();
            return db.Users.OrderBy(u => u.Name).ToList();
        }

        /// <summary>
        /// Gets the users without workers.
        /// </summary>
        /// <returns></returns>
        public static List<User> GetFullUsersWithoutWorkers()
        {
            KinoDb db = new KinoDb();
            List<User> users = (from u in db.Users
                         where u.IsUser == true
                         select u).OrderBy(u => u.Name).ToList<User>();

            return users;
        }

        /// <summary>
        /// Updates the user.
        /// </summary>
        /// <param name="user">The user to be updated in database.</param>
        public static void NullTokenUser(String pesel)
        {
            KinoDb db = new KinoDb();
            User user = db.Users.Where(u => u.PESEL == pesel).First();

            user.ActiveToken = null;

            db.SaveChanges();
        }

        public static void setUserPhone(String pesel, String phoneNumber)
        {
            KinoDb db = new KinoDb();
            User user = db.Users.Where(u => u.PESEL == pesel).First();

            user.Phone = phoneNumber;

            db.SaveChanges();
        }

        /// <summary>
        /// Creates new User.
        /// </summary>
        /// <param name="evaluationId">The evaluation id.</param>
        public static User CreateUser(String name, String surname, String pesel, String address, String email,
            DateTime creationDate)
        {
            KinoDb db = new KinoDb();
            User user = new User
            {
                PESEL = pesel,
                Name = name,
                Surname = surname,
                Address = address,
                Email = email,
                ActiveToken = GenerateNewToken(),
                CreateDate = creationDate,
                LastActivity = creationDate,
                IsUser = true
            };
            db.Users.Add(user);
            db.SaveChanges();

            return user;
        }

        public static void DeleteUser(String pesel)
        {
            KinoDb db = new KinoDb();

            User userToDelete = (from u in db.Users
                                 where u.PESEL == pesel
                                 select u).First();
            if (userToDelete != null)
            {
                db.Users.Remove(userToDelete);
                db.SaveChanges();

                Roles.RemoveUserFromRole(userToDelete.PESEL, "User");
                Membership.DeleteUser(userToDelete.PESEL);
            }
        }

        public static string GetUserCulture(string name)
        {
            KinoDb db = new KinoDb();
            User user = GetUser(name);
            if (user != null)
            {
                return user.Culture;
            }
            else return null;
        }

        public static void SetUserCulture(string pesel, string lang)
        {
            KinoDb db = new KinoDb();
            User user = db.Users.Where(u => u.PESEL == pesel).FirstOrDefault();
            if (user != null)
            {
                user.Culture = lang;
            }

            db.SaveChanges();
        }

        public static int CheckUser(String name, String password)
        {
            MembershipUser user = Membership.GetUser(name);

            if (user == null)
                return 1;
            if (!user.IsApproved)
                return 2;
            if (!Membership.ValidateUser(name, password))
                return 3;

            return 0;
        }

        #endregion

        public static void AddReservation(int filmShowId, int userId, int price, string name, string surname, string filmname)
        {
            KinoDb db = new KinoDb();
            Reservation res = new Reservation
            {
                ReservationId = GenerateReservationId(name, surname, filmname),
                Price = price,
                Discount = 1,
                Finished = false,
                Owner = userId,
                FilmShow = filmShowId
            };
            db.Reservations.Add(res);
            db.SaveChanges();
        }

        public static List<Reservation> GetReservations(int userId)
        {
            KinoDb db = new KinoDb();
            List<Reservation> res = (from r in db.Reservations
                             where r.Owner == userId
                             select r).ToList();

            

            return res;
        }

        public static FilmShow GetFilmShow(string name, DateTime date)
        {
            KinoDb db = new KinoDb();
            FilmShow show = (from s in db.FilmShows
                             where s.Date == date && s.Film == name
                             select s).FirstOrDefault();

            return show;
        }

        public static List<string> GetSeanses(DateTime date)
        {
            KinoDb db = new KinoDb();
            List<string> shows = (from s in db.FilmShows
                                    where s.Date == date
                                    select s.Film).Distinct().ToList();
            return shows;
        }

        public static List<DateTime> GetTimesOfSeans(DateTime date, String filmName)
        {
            KinoDb db = new KinoDb();
            List<DateTime> showsTime = (from s in db.FilmShows
                                    where (s.Date == date && s.Film.Equals(filmName))
                                    select s.Time).OrderBy(s => s.Hour).ToList();

            return showsTime;
        }

        public static List<Room> GetRooms()
        {
            KinoDb db = new KinoDb();
            return db.Rooms.OrderBy(r => r.RoomNumber).ToList();
        }

        public static List<Film> GetFilms()
        {
            KinoDb db = new KinoDb();
            return db.Films.OrderBy(f => f.Title).ToList();
        }

        public static string GenerateNewToken()
        {
            string token = "";
            char[] chars = new char[62];
            chars = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ1234567890".ToCharArray();
            Random rand = new Random();
            for (int i = 0; i < 20; i++)
                token += chars[rand.Next(62)];
            return token;
        }

        public static string GenerateReservationId(string name, string surname, string filmName) 
        {
            Random rand = new Random();
            return filmName.Substring(0,3) + DateTime.Today.ToString("yyyy.MM.dd.hh") + name.Substring(0, 1) + surname.Substring(0, 1) +rand.Next(999); 
        }
    }
}