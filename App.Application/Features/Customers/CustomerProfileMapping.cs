﻿using App.Application.Features.Customers.Create;
using App.Application.Features.Customers.Dto;
using App.Application.Features.Customers.Update;
using App.Application.Features.Customers.UpdateEmail;
using App.Application.Features.Events.Create;
using App.Application.Features.Events.Update;
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
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LastName.ToLowerInvariant()));

            CreateMap<UpdateEmailCustomerRequest, Customer>()
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email.ToLowerInvariant()));

            CreateMap<CreateCustomerRequest, Customer>()
                .ForMember(dest => dest.Created, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(_ => DateTime.Now));

            CreateMap<UpdateCustomerRequest, Customer>()
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}
