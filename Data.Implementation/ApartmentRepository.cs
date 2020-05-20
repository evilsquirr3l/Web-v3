using System.Linq;
using System.Threading.Tasks;
using Data.Abstraction;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Data.Implementation
{
    public class ApartmentRepository : Repository<Apartment>, IApartmentRepository
    {
        public ApartmentRepository(MapDbContext context) : base(context)
        {
        }

        public IQueryable<Apartment> GetApartmentsWithDetails()
        {
            return FindAll()
                .Include(a => a.Residents)
                .ThenInclude(ar => ar.Resident);
        }
        
        public async Task<Apartment> GetApartmentWithDataById(int id)
        {
            return await FindByCondition(a => a.Id == id)
                .Include(a => a.House)
                .Include(a => a.Residents)
                .ThenInclude(r => r.Resident)
                .SingleOrDefaultAsync();
        }
    }
}