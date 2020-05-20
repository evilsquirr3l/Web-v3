using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Abstraction
{
    public interface IApartmentRepository : IRepository<Apartment>
    {
        Task<Apartment> GetApartmentWithDataById(int id);

        IQueryable<Apartment> GetApartmentsWithDetails();
    }
}