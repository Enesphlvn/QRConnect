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
            CreateMap<DistrictDto, District>().ReverseMap();
            CreateMap<DistrictWithVenuesDto, District>().ReverseMap();
            CreateMap<CreateDistrictRequest, District>();
            CreateMap<UpdateDistrictRequest, District>();
        }
    }
}
