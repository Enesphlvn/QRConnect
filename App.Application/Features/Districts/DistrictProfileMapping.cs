using App.Application.Features.Districts.Create;
using App.Application.Features.Districts.Dto;
using App.Application.Features.Districts.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Globalization;

namespace App.Application.Features.Districts
{
    public class DistrictProfileMapping : Profile
    {
        public DistrictProfileMapping()
        {
            CreateMap<DistrictDto, District>().ReverseMap();

            CreateMap<CreateDistrictRequest, District>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLower(new CultureInfo("tr-TR"))));

            CreateMap<UpdateDistrictRequest, District>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLower(new CultureInfo("tr-TR"))));
        }
    }
}
