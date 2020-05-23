using AutoMapper;
using Business.Abstraction;
using Business.Implementation.Configurations;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Implementation
{
    public static class BusinessServices
    {
        public static IServiceCollection RegisterBusinessServices(this IServiceCollection services)
        {
            services.AddTransient<IApartmentService, ApartmentService>();
            services.AddTransient<IMapService, MapService>();
            services.AddTransient<IResidentService, ResidentService>();
            services.AddTransient<IUserService, UserService>();
            
            var mapperConfig = new MapperConfiguration(c => c.AddProfile(new AutomapperProfile()));
            var mapper = mapperConfig.CreateMapper();

            services.AddSingleton(mapper);

            return services;
        }
    }
}