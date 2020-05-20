using System.Linq;
using System.Threading.Tasks;
using Data.Entities;

namespace Data.Abstraction
{
    public interface IResidentRepository : IRepository<Resident>
    {
        Task<Resident> GetResidentWithApartmentsById(int id);
        
        IQueryable<Resident> GetResidentsWithDetails();
    }
}