using System.Threading.Tasks;
using Data.Entities;

namespace Data.Abstraction
{
    public interface IUnitOfWork
    {
        public IRepository<Apartment> ApartmentRepository { get; }

        public IRepository<City> CityRepository { get; }

        public IRepository<Country> CountryRepository { get; }

        public IRepository<House> HouseRepository { get;  }

        public IRepository<Resident> ResidentRepository { get; }

        public IRepository<Street> StreetRepository { get; }

        Task<int> SaveAsync();
    }
}