﻿using App.Application.Features.Users;
using App.Application.Features.Events;
using App.Application.Features.QRCodes;
using App.Application.Features.Tickets;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using App.Application.Features.Cities;
using App.Application.Features.Districts;
using App.Application.Features.EventTypes;
using App.Application.Features.OperationClaims;
using App.Application.Features.Passwords;
using App.Application.Features.Venues;
using App.Application.Features.UserOperationClaims;

namespace App.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.Configure<ApiBehaviorOptions>(options => options.SuppressModelStateInvalidFilter = true);

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICityService, CityService>();
            services.AddScoped<IEventService, EventService>();
            services.AddScoped<IVenueService, VenueService>();
            services.AddScoped<IQRCodeService, QRCodeService>();
            services.AddScoped<ITicketService, TicketService>();
            services.AddScoped<IDistrictService, DistrictService>();
            services.AddScoped<IEventTypeService, EventTypeService>();
            services.AddScoped<IOperationClaimService, OperationClaimService>();
            services.AddScoped<IPasswordHashingService, PasswordHashingService>();
            services.AddScoped<IUserOperationClaimService, UserOperationClaimService>();

            services.AddFluentValidationAutoValidation();

            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}