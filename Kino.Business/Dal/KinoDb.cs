using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using Kino.Business.Entity;
using System.ComponentModel.DataAnnotations;

namespace Kino.Business.Dal
{
    internal class KinoDb : DbContext
    {
        public DbSet<Film> Films { get; set; }
        public DbSet<FilmShow> FilmShows { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<ReservationPlace> ReservationPlaces { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Film>().ToTable("Films");
            modelBuilder.Entity<FilmShow>().ToTable("FilmShows");
            modelBuilder.Entity<Report>().ToTable("Reports");
            modelBuilder.Entity<Reservation>().ToTable("Reservations");
            modelBuilder.Entity<ReservationPlace>().ToTable("ReservationPlaces");
            modelBuilder.Entity<Room>().ToTable("Rooms");
            modelBuilder.Entity<User>().ToTable("Users");
        }
    }
}
