using App.Application.Features.OperationClaims.Create;
using App.Application.Features.OperationClaims.Dto;
using App.Application.Features.OperationClaims.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.OperationClaims
{
    public class OperationClaimProfileMapping : Profile
    {
        public OperationClaimProfileMapping()
        {
            CreateMap<OperationClaimDto, OperationClaim>().ReverseMap();

            CreateMap<CreateOperationClaimRequest, OperationClaim>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.IsStatus, opt => opt.MapFrom(_ => true));

            CreateMap<UpdateOperationClaimRequest, OperationClaim>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}
