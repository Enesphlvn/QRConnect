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

            CreateMap<CreateEventRequest, Event>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.ToLowerInvariant()));

            CreateMap<UpdateEventRequest, Event>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Name.ToLowerInvariant()))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address.ToLowerInvariant()));
        }
    }
}
