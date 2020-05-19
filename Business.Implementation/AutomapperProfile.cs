using System;
using System.Linq;
using AutoMapper;
using Business.Models;
using Data.Entities;

namespace Business.Implementation
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<City, CityModel>().ReverseMap();

            CreateMap<Country, CountryModel>().ReverseMap();

            CreateMap<House, HouseModel>().ReverseMap();

            CreateMap<Resident, ResidentModel>().ReverseMap();

            CreateMap<Street, StreetModel>().ReverseMap();

            CreateMap<Apartment, ApartmentModel>()
                .ForMember(a => a.Residents,
                    opt => opt.MapFrom(a => a.Residents.Select(r => r.Resident)))
                .ReverseMap()
                .ForMember(a => a.Residents,
                    opt => opt.MapFrom(a =>
                        a.Residents.Select(resident => new ApartmentResidents {ResidentId = resident.Id})));

            CreateMap<Resident, ResidentModel>()
                .ForMember(r => r.Apartments,
                    opt => opt.MapFrom(r => r.Apartments.Select(a => a.Apartment)))
                .ReverseMap()
                .ForMember(r => r.Apartments,
                    opt => opt.MapFrom(r =>
                        r.Apartments.Select(apartment => new ApartmentResidents {ApartmentId = apartment.Id})));
        }
    }
}