using App.Application.Features.EventTypes.Create;
using App.Application.Features.EventTypes.Dto;
using App.Application.Features.EventTypes.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.EventTypes
{
    public class EventTypeProfileMapping : Profile
    {
        public EventTypeProfileMapping()
        {
            CreateMap<EventTypeDto, EventType>().ReverseMap();

            CreateMap<CreateEventTypeRequest, EventType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.IsStatus, opt => opt.MapFrom(_ => true));

            CreateMap<UpdateEventTypeRequest, EventType>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()))
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}
