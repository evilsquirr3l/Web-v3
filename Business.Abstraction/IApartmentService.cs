using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;

namespace Business.Abstraction
{
    public interface IApartmentService
    {
        IEnumerable<ApartmentModel> GetAll();
        
        Task AddResidentToApartment(int apartmentId, int residentId);
    }
}