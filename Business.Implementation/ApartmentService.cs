using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstraction;
using Business.Implementation.Validation;
using Business.Models;
using Data.Abstraction;

namespace Business.Implementation
{
    public class ApartmentService : IApartmentService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ApartmentService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public async Task AddResidentToApartment(int apartmentId, int residentId)
        {
            var resident = _unit.ResidentRepository.FindByCondition(r => r.Id == residentId).SingleOrDefault();
            var apartment = _unit.ApartmentRepository.FindByCondition(a => a.Id == apartmentId).SingleOrDefault();

            resident.AssertIsNotNull();
            apartment.AssertIsNotNull();
            
            var apartmentResidentsNumber = apartment.Residents.Select(ar => ar.Resident).Count();

            if (apartment.Square / apartmentResidentsNumber < 9)
            {
                throw new BusinessException("Apartment square for 1 person should be at least 9 square meters.");
            }
            
            _unit.ResidentRepository.Update(resident);
            await _unit.SaveAsync();
        }
    }
}