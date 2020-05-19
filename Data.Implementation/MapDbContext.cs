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

            var apartment1 = new Apartment()
            {
                Id = 1,
                Type = "Serdychka flat",
                HouseId = 1
            };
            
            var resident1 = new Resident()
            {
                Id = 1,
                Name = "Max Snizhok",
                BirthDate = DateTime.Now.AddYears(-18), //always 18 y.o. with birthday = today
            };
            
            var apartmentResident1 = new ApartmentResidents()
            {
                ApartmentId = 1,
                ResidentId = 1
            };
            
            var apartment2 = new Apartment()
            {
                Id = 2,
                Type = "Nirvana",
                HouseId = 1
            };
            
            var resident2 = new Resident()
            {
                Id = 2,
                Name = "Kurtka Bayne",
                BirthDate = DateTime.Now.AddYears(-27)
            };
            
            var apartmentResident2 = new ApartmentResidents()
            {
                ApartmentId = 2,
                ResidentId = 2
            };
            
            var country1 = new Country()
            {
                Id = 1,
                Name = "Ukraine"
            };
            
            var city1 = new City()
            {
                Id = 1,
                Name = "Kyiv",
                Population = 2000000,
                CountryId = 1
            };
            
            var street1 = new Street()
            {
                Id = 1,
                Name = "Khreshchatyk",
                CityId = 1
            };
            
            var house1 = new House()
            {
                Id = 1,
                Latitude = 50.44,
                Longitude = 30.52,
                StreetId = 1
            };

            modelBuilder.Entity<Apartment>().HasData(apartment1, apartment2);
            modelBuilder.Entity<ApartmentResidents>().HasData(apartmentResident1, apartmentResident2);
            modelBuilder.Entity<Resident>().HasData(resident1, resident2);
            modelBuilder.Entity<City>().HasData(city1);
            modelBuilder.Entity<Country>().HasData(country1);
            modelBuilder.Entity<House>().HasData(house1);
            modelBuilder.Entity<Street>().HasData(street1);
            #endregion

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}