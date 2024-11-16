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
            CreateMap<UserOperationClaimDto, UserOperationClaim>().ReverseMap();

            CreateMap<UpdateUserOperationClaimRequest, UserOperationClaim>();

            CreateMap<CreateUserOperationClaimRequest, UserOperationClaim>();
        }
    }
}
