using App.Application.Features.EventTypes.Create;
using App.Application.Features.EventTypes.Dto;
using App.Application.Features.EventTypes.Update;
using App.Domain.Entities;
using AutoMapper;
using System.Globalization;

namespace App.Application.Features.EventTypes
{
    public class EventTypeProfileMapping : Profile
    {
        public EventTypeProfileMapping()
        {
            CreateMap<EventTypeDto, EventType>().ReverseMap();

            CreateMap<CreateEventTypeRequest, EventType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLower(new CultureInfo("tr-TR"))));

            CreateMap<UpdateEventTypeRequest, EventType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLower(new CultureInfo("tr-TR"))));
        }
    }
}
