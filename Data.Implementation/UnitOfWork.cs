using System.Threading.Tasks;
using Data.Abstraction;
using Data.Entities;
using Microsoft.AspNetCore.Identity;

namespace Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MapDbContext _context;

        public UnitOfWork(MapDbContext context, IApartmentRepository apartmentRepository, 
            IRepository<City> cityRepository, IRepository<Country> countryRepository, 
            IRepository<House> houseRepository, IResidentRepository residentRepository, 
            IRepository<Street> streetRepository, IRepository<ApartmentResidents> apartmentResidentsRepository, 
            UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _context = context;
            ApartmentRepository = apartmentRepository;
            CityRepository = cityRepository;
            CountryRepository = countryRepository;
            HouseRepository = houseRepository;
            ResidentRepository = residentRepository;
            StreetRepository = streetRepository;
            ApartmentResidentsRepository = apartmentResidentsRepository;
            UserManager = userManager;
            SignInManager = signInManager;
        }

        public IApartmentRepository ApartmentRepository { get; }
        
        public IRepository<City> CityRepository { get; }
        
        public IRepository<Country> CountryRepository { get; }
        
        public IRepository<House> HouseRepository { get; }

        public IResidentRepository ResidentRepository { get; }
        
        public IRepository<Street> StreetRepository { get; }

        public IRepository<ApartmentResidents> ApartmentResidentsRepository { get; }
        
        public UserManager<User> UserManager { get; }
        
        public SignInManager<User> SignInManager { get; }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}