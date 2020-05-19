using System.Threading.Tasks;
using Business.Models;

namespace Business.Abstraction
{
    public interface IApartmentService
    {
        Task AddResidentToApartment(int apartmentId, int residentId);
    }
}