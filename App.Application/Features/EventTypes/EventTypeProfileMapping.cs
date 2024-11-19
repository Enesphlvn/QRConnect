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

            CreateMap<EventTypeWithEventsDto, EventType>().ReverseMap();

            CreateMap<CreateEventTypeRequest, EventType>();

            CreateMap<UpdateEventTypeRequest, EventType>();
        }
    }
}
