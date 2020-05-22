using Data.Abstraction;
using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Implementation
{
    public static class DataServices
    {
        public static IServiceCollection RegisterDataServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<MapDbContext>(options =>
                options.UseSqlServer(connectionString));

            services.AddIdentityCore<User>().AddEntityFrameworkStores<MapDbContext>();

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            
            services.AddScoped<IResidentRepository, ResidentRepository>();
            
            services.AddScoped<IApartmentRepository, ApartmentRepository>();

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}