using App.Application.Features.Users.Create;
using App.Application.Features.Users.Dto;
using App.Application.Features.Users.Update;
using App.Application.Features.Users.UpdateEmail;
using App.Application.Features.Users.UpdatePassword;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Users
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<CreateUserRequest, User>();

            CreateMap<UpdateUserRequest, User>();

            CreateMap<UpdateEmailUserRequest, User>();

            CreateMap<UpdatePasswordUserRequest, User>();
        }
    }
}
