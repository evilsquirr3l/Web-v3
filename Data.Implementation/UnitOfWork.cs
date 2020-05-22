using System.Threading.Tasks;
using Data.Abstraction;
using Data.Entities;

namespace Data.Implementation
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MapDbContext _context;

        public UnitOfWork(MapDbContext context, IApartmentRepository apartmentRepository, 
            IRepository<City> cityRepository, IRepository<Country> countryRepository, 
            IRepository<House> houseRepository, IResidentRepository residentRepository, 
            IRepository<Street> streetRepository, IRepository<ApartmentResidents> apartmentResidentsRepository)
        {
            _context = context;
            ApartmentRepository = apartmentRepository;
            CityRepository = cityRepository;
            CountryRepository = countryRepository;
            HouseRepository = houseRepository;
            ResidentRepository = residentRepository;
            StreetRepository = streetRepository;
            ApartmentResidentsRepository = apartmentResidentsRepository;
        }

        public IApartmentRepository ApartmentRepository { get; }
        
        public IRepository<City> CityRepository { get; }
        
        public IRepository<Country> CountryRepository { get; }
        
        public IRepository<House> HouseRepository { get; }

        public IResidentRepository ResidentRepository { get; }
        
        public IRepository<Street> StreetRepository { get; }

        public IRepository<ApartmentResidents> ApartmentResidentsRepository { get; }
        
        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}