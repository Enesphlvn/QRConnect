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
            CreateMap<EventResponse, Event>().ReverseMap();
            CreateMap<EventWithDetailResponse, Event>().ReverseMap();
            CreateMap<Event, EventsByEventTypeResponse>().ReverseMap();
            CreateMap<Event, EventsByVenueResponse>().ReverseMap();
            CreateMap<Event, EventsWithHighestSalesResponse>().ReverseMap();
            CreateMap<Event, EventsByUserTicketsResponse>().ReverseMap();
            CreateMap<CreateEventRequest, Event>();
            CreateMap<UpdateEventRequest, Event>();
        }
    }
}
