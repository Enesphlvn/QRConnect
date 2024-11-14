using App.Application.Features.OperationClaims.Create;
using App.Application.Features.OperationClaims.Dto;
using App.Application.Features.OperationClaims.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Globalization;

namespace App.Application.Features.OperationClaims
{
    public class OperationClaimProfileMapping : Profile
    {
        public OperationClaimProfileMapping()
        {
            CreateMap<OperationClaimDto, OperationClaim>().ReverseMap();

            CreateMap<CreateOperationClaimRequest, OperationClaim>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLower(new CultureInfo("tr-TR"))));

            CreateMap<UpdateOperationClaimRequest, OperationClaim>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLower(new CultureInfo("tr-TR"))));
        }
    }
}
