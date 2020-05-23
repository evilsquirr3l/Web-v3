using System.Threading.Tasks;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

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

        public IRepository<ApartmentResidents> ApartmentResidentsRepository { get; }
        
        public UserManager<User> UserManager { get; } 
        
        public SignInManager<User> SignInManager { get; } 

        Task<int> SaveAsync();
    }
}