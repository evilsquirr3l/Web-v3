using System.Threading.Tasks;
using Business.Models;

namespace Business.Abstraction
{
    public interface IApartmentService
    {
        Task<bool> AddResidentToApartment(ApartmentModel apartmentModel, ResidentModel residentModel);
    }
}