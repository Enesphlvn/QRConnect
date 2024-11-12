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

            CreateMap<CreateDistrictRequest, District>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.IsStatus, opt => opt.MapFrom(_ => true));

            CreateMap<UpdateDistrictRequest, District>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}
