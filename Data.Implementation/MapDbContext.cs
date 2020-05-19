using System;
using System.Reflection;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class MapDbContext : DbContext
    {
        public MapDbContext(DbContextOptions<MapDbContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<ApartmentResidents> ApartmentResidents { get; set; }

        public DbSet<City> Cities { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<House> Houses { get; set; }

        public DbSet<Resident> Residents { get; set; }

        public DbSet<Street> Streets { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region SeedData

            // var apartment1 = new Apartment()
            // {
            //     Id = 1,
            //     Type = "Hostel"
            // };
            //
            // var resident1 = new Resident()
            // {
            //     Id = 1,
            //     Name = "Max Snizhok",
            //     BirthDate = DateTime.Now.AddYears(-18), //always 18 y.o. with birthday = today
            // };
            //
            // var apartmentResident1 = new ApartmentResidents()
            // {
            //     ApartmentId = 1,
            //     ResidentId = 1
            // };
            //
            // var apartment2 = new Apartment()
            // {
            //     Id = 2,
            //     Type = "Hostel"
            // };
            //
            // var resident2 = new Resident()
            // {
            //     Id = 2,
            //     Name = "Kurtka Bayne",
            //     BirthDate = DateTime.Now.AddYears(-27)
            // };
            //
            // var apartmentResident2 = new ApartmentResidents()
            // {
            //     ApartmentId = 2,
            //     ResidentId = 2
            // };
            //
            // var city1 = new City()
            // {
            //     Id = 1,
            //     Name = "Kyiv",
            //     Population = 2000000
            // };
            //
            // var street1 = new Street()
            // {
            //     Id = 1,
            //     Name = "Khreshchatyk"
            // };

            #endregion

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}