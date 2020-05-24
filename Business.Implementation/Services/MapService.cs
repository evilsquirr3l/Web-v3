using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Business.Abstraction;
using Business.Models;
using Data.Abstraction;

namespace Business.Implementation.Services
{
    public class MapService : IMapService
    {
        private readonly IUnitOfWork _unit;
        private readonly IMapper _mapper;

        public MapService(IMapper mapper, IUnitOfWork unit)
        {
            _mapper = mapper;
            _unit = unit;
        }

        public IEnumerable<CityModel> FindCityByName(string name)
        {
            var citiesWithName = _unit.CityRepository.FindByCondition(c => c.Name.Contains(name)).ToList();

            return _mapper.Map<IEnumerable<CityModel>>(citiesWithName);
        }

        public IEnumerable<CityModel> FindCityByPopulation(int population)
        {
            var citiesWithPopulation = _unit.CityRepository.FindByCondition(c => c.Population == population).ToList();

            return _mapper.Map<IEnumerable<CityModel>>(citiesWithPopulation);
        }

        public IEnumerable<CityModel> FindCityByStreet(CitySearchModel searchModel)
        {
            var citiesWithStreet = _unit.CityRepository.FindByCondition(c => c.Streets.Select(s => s.Name).Contains(searchModel.StreetName)).ToList();

            if (!searchModel.HouseNumber.HasValue) return _mapper.Map<IEnumerable<CityModel>>(citiesWithStreet);
            {
                var citiesWithStreetThatHasHouseWithNumber = citiesWithStreet.Where(c => c.Streets.Any(s => s.Houses.Any(h => h.Id == searchModel.HouseNumber)));
                
                return _mapper.Map<IEnumerable<CityModel>>(citiesWithStreetThatHasHouseWithNumber);
            }
        }
    }
}