using App.Application.Features.Users.Create;
using App.Application.Features.Users.Dto;
using App.Application.Features.Users.Update;
using App.Application.Features.Users.UpdateEmail;
using App.Application.Features.Users.UpdatePassword;
using App.Domain.Entities;
using AutoMapper;
using System.Globalization;

namespace App.Application.Features.Users
{
    public class UserProfileMapping : Profile
    {
        public UserProfileMapping()
        {
            CreateMap<UserDto, User>().ReverseMap();

            CreateMap<CreateUserRequest, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.ToLower(new CultureInfo("tr-TR"))))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.ToLower(new CultureInfo("tr-TR"))))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLower(new CultureInfo("tr-TR"))))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.IsStatus, opt => opt.MapFrom(_ => true));

            CreateMap<UpdateUserRequest, User>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.ToLower(new CultureInfo("tr-TR"))))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.ToLower(new CultureInfo("tr-TR"))))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<UpdateEmailUserRequest, User>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLower(new CultureInfo("tr-TR"))))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<UpdatePasswordUserRequest, User>()
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}
