using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Abstraction;
using Business.Models;
using Microsoft.AspNetCore.Mvc;

namespace Map.API.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class MapController : ControllerBase
    {
        private readonly IMapService _mapService;

        public MapController(IMapService mapService)
        {
            _mapService = mapService;
        }

        [HttpGet("{name}")]
        public ActionResult<IEnumerable<CityModel>> FindCityByName(string name)
        {
            var cities = _mapService.FindCityByName(name);

            return Ok(cities);
        }
        
        [HttpGet("{population:int}")]
        public ActionResult<IEnumerable<CityModel>> FindCityByPopulation(int population)
        {
            var cities = _mapService.FindCityByPopulation(population);

            return Ok(cities);
        }
        
        [HttpGet]
        public ActionResult<IEnumerable<CityModel>> FindCityByStreet([FromBody]CitySearchModel searchModel)
        {
            var cities = _mapService.FindCityByStreet(searchModel);

            return Ok(cities);
        }
    }
}