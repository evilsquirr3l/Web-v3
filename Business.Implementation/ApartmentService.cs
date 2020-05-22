using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Business.Abstraction;
using Business.Implementation.Validation;
using Business.Models;
using Data.Abstraction;
using Data.Entities;

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

        public IEnumerable<ApartmentModel> GetAll()
        {
            var apartments = _unit.ApartmentRepository.GetApartmentsWithDetails().ToList();
            
            return _mapper.Map<IEnumerable<ApartmentModel>>(apartments);
        }

        public async Task AddResidentToApartment(int apartmentId, int residentId)
        {
            var resident = await _unit.ResidentRepository.GetResidentWithApartmentsById(residentId);
            var apartment = await _unit.ApartmentRepository.GetApartmentWithDataById(apartmentId);

            resident.AssertIsNotNull();
            apartment.AssertIsNotNull();
            
            var apartmentResidentsNumber = apartment.Residents.Select(ar => ar.Resident).Count();

            if (apartment.Square / apartmentResidentsNumber < 9)
            {
                throw new BusinessException("Apartment square for 1 person should be at least 9 square meters.");
            }

            var apartmentResident = new ApartmentResidents {ApartmentId = apartmentId, ResidentId = residentId};
            await _unit.ApartmentResidentsRepository.Create(apartmentResident);
           
            await _unit.SaveAsync();
        }
    }
}