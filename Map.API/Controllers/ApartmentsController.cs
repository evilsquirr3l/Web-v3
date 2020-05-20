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
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentService _apartmentService;

        public ApartmentsController(IApartmentService apartmentService)
        {
            _apartmentService = apartmentService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ApartmentModel>> GetApartments()
        {
            var apartments = _apartmentService.GetAll();
            
            return Ok(apartments);
        }
        
        [HttpPost]
        public async Task<ActionResult> AddResidentToApartment(int apartmentId, int residentId)
        {
            await _apartmentService.AddResidentToApartment(apartmentId, residentId);

            return Ok();
        }
    }
}