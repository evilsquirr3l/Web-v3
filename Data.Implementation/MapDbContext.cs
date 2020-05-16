using System.Reflection;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class MapDbContext : DbContext
    {
        public MapDbContext(DbContextOptions<MapDbContext> options) : base(options)
        {
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

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}