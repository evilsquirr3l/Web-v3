using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Abstraction;
using Business.Models;
using Data.Abstraction;

namespace Business.Implementation
{
    public class ResidentService : IResidentService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public ResidentService(IUnitOfWork unit, IMapper mapper)
        {
            _unit = unit;
            _mapper = mapper;
        }

        public IEnumerable<ResidentModel> FindByName(string name)
        {
            var residentsWithSelectedName =
                _unit.ResidentRepository.FindByCondition(r => r.Name.Contains(name)).ToList();

            return _mapper.Map<IEnumerable<ResidentModel>>(residentsWithSelectedName);
        }

        public IEnumerable<ResidentModel> FindByBirthdate(DateTime birthdate)
        {
            var residentsWithSelectedBirthdate = _unit.ResidentRepository
                .FindByCondition(r => r.BirthDate.Date == birthdate.Date).ToList();

            return _mapper.Map<IEnumerable<ResidentModel>>(residentsWithSelectedBirthdate);
        }

        public IEnumerable<ResidentModel> FindByNumberOfApartments(int numberOfApartments)
        {
            var residentsWithSelectedNumberOfApartments = _unit.ResidentRepository
                .FindByCondition(r => r.Apartments.Select(ar => ar.Apartment).Count() == numberOfApartments).ToList();

            return _mapper.Map<IEnumerable<ResidentModel>>(residentsWithSelectedNumberOfApartments);
        }
    }
}