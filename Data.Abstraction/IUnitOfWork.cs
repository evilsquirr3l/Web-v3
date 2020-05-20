using System.Threading.Tasks;
using Data.Entities;

namespace Data.Abstraction
{
    public interface IUnitOfWork
    {
        public IApartmentRepository ApartmentRepository { get; }

        public IRepository<City> CityRepository { get; }

        public IRepository<Country> CountryRepository { get; }

        public IRepository<House> HouseRepository { get;  }

        public IResidentRepository ResidentRepository { get; }

        public IRepository<Street> StreetRepository { get; }

        Task<int> SaveAsync();
    }
}