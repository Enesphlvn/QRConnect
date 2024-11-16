using App.Application.Features.Cities.Create;
using App.Application.Features.Cities.Dto;
using App.Application.Features.Cities.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Cities
{
    public class CityProfileMapping : Profile
    {
        public CityProfileMapping()
        {
            CreateMap<CityDto, City>().ReverseMap();

            CreateMap<CreateCityRequest, City>();

            CreateMap<UpdateCityRequest, City>();
        }
    }
}