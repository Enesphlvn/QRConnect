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
            CreateMap<OperationClaimResponse, OperationClaim>().ReverseMap();
            CreateMap<CreateOperationClaimRequest, OperationClaim>();
            CreateMap<OperationClaim, OperationClaimWithUserOperationClaimsResponse>();
            CreateMap<UpdateOperationClaimRequest, OperationClaim>();
        }
    }
}
