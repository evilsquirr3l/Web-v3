using System;
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
    public class ResidentsController : ControllerBase
    {
        private readonly IResidentService _residentService;

        public ResidentsController(IResidentService residentService)
        {
            _residentService = residentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ResidentModel>> GetAll()
        {
            var residents = _residentService.GetAll();

            return Ok(residents);
        }

        [HttpGet("{birthdate:datetime}")]
        public ActionResult<IEnumerable<ResidentModel>> GetByBirthdate(DateTime birthdate)
        {
            var residents = _residentService.FindByBirthdate(birthdate);

            return Ok(residents);
        }
        
        [HttpGet("{name}")]
        public ActionResult<IEnumerable<ResidentModel>> GetByName(string name)
        {
            var residents = _residentService.FindByName(name);

            return Ok(residents);
        }
        
        [HttpGet("{numberOfApartments:int}")]
        public ActionResult<IEnumerable<ResidentModel>> GetByNumberOfApartments(int numberOfApartments)
        {
            var residents = _residentService.FindByNumberOfApartments(numberOfApartments);

            return Ok(residents);
        }
    }
}