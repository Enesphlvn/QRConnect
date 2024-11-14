﻿using App.Application.Features.Cities.Create;
using App.Application.Features.Cities.Dto;
using App.Application.Features.Cities.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Globalization;

namespace App.Application.Features.Cities
{
    public class CityProfileMapping : Profile
    {
        public CityProfileMapping()
        {
            CreateMap<CityDto, City>().ReverseMap();

            CreateMap<CreateCityRequest, City>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLower(new CultureInfo("tr-TR"))));

            CreateMap<UpdateCityRequest, City>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLower(new CultureInfo("tr-TR"))));
        }
    }
}