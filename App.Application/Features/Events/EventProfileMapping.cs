using App.Application.Features.Events.Create;
using App.Application.Features.Events.Dto;
using App.Application.Features.Events.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Events
{
    public class EventProfileMapping : Profile
    {
        public EventProfileMapping()
        {
            CreateMap<EventDto, Event>().ReverseMap();

            CreateMap<Event, EventsByEventTypeDto>().ReverseMap();

            CreateMap<CreateEventRequest, Event>();

            CreateMap<UpdateEventRequest, Event>();
        }
    }
}
