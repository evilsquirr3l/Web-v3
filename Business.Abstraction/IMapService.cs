using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Abstraction
{
    public interface IMapService
    {
        Task<IEnumerable<CityModel>> FindCityByName(string name);
        
        Task<IEnumerable<CityModel>> FindCityByPopulation(double population);
        
        Task<IEnumerable<CityModel>> FindCityByStreet(double population, int? houseId = null);
    }
}