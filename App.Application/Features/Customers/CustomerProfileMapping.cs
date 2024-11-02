using App.Application.Features.Customers.Create;
using App.Application.Features.Customers.Dto;
using App.Application.Features.Customers.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Customers
{
    public class CustomerProfileMapping : Profile
    {
        public CustomerProfileMapping()
        {
            CreateMap<CustomerDto, Customer>().ReverseMap();

            CreateMap<CreateCustomerRequest, Customer>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.ToLowerInvariant()))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.ToLowerInvariant()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLowerInvariant()));

            CreateMap<UpdateCustomerRequest, Customer>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FirstName.ToLowerInvariant()))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.ToLowerInvariant()))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLowerInvariant()));
        }
    }
}
