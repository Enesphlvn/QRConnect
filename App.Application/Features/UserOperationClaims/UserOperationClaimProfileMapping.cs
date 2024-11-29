using App.Application.Features.UserOperationClaims.Create;
using App.Application.Features.UserOperationClaims.Dto;
using App.Application.Features.UserOperationClaims.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.UserOperationClaims
{
    public class UserOperationClaimProfileMapping : Profile
    {
        public UserOperationClaimProfileMapping()
        {
            CreateMap<UserOperationClaimResponse, UserOperationClaim>().ReverseMap();
            CreateMap<UpdateUserOperationClaimRequest, UserOperationClaim>();
            CreateMap<UserOperationClaim, UserOperationClaimWithDetailResponse>();
            CreateMap<UserOperationClaim, UserOperationClaimByUserResponse>().ReverseMap();
            CreateMap<UserOperationClaim, UserOperationClaimByOperationClaimResponse>().ReverseMap();
            CreateMap<CreateUserOperationClaimRequest, UserOperationClaim>();
        }
    }
}
