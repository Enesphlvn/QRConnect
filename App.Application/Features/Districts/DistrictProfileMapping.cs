using App.Application.Features.Districts.Create;
using App.Application.Features.Districts.Dto;
using App.Application.Features.Districts.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Districts
{
    public class DistrictProfileMapping : Profile
    {
        public DistrictProfileMapping()
        {
            CreateMap<DistrictResponse, District>().ReverseMap();
            CreateMap<DistrictWithVenuesResponse, District>().ReverseMap();
            CreateMap<DistrictsByCityResponse, District>().ReverseMap();
            CreateMap<CreateDistrictRequest, District>();
            CreateMap<UpdateDistrictRequest, District>();
        }
    }
}
