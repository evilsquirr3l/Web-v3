using System.Linq;
using System.Threading.Tasks;
using Data.Abstraction;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class ResidentRepository : Repository<Resident>, IResidentRepository 
    {
        public ResidentRepository(MapDbContext context) : base(context)
        {
        }

        public async Task<Resident> GetResidentWithApartmentsById(int id)
        {
            return await FindByCondition(r => r.Id == id).Include(r => r.Apartments).SingleOrDefaultAsync();
        }

        public IQueryable<Resident> GetResidentsWithDetails()
        {
            return FindAll()
                .Include(r => r.Apartments)
                .ThenInclude(ar => ar.Apartment);
        }
    }
}