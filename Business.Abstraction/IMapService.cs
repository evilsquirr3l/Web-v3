using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Abstraction
{
    public interface IMapService
    {
        IEnumerable<CityModel> FindCityByName(string name);
        
        IEnumerable<CityModel> FindCityByPopulation(int population);
        
        IEnumerable<CityModel> FindCityByStreet(CitySearchModel searchModel);
    }
}