using App.Application.Features.Tickets.Create;
using App.Application.Features.Tickets.Dto;
using App.Application.Features.Tickets.Update;
using App.Domain.Entities;
using AutoMapper;

namespace App.Application.Features.Tickets
{
    public class TicketProfileMapping : Profile
    {
        public TicketProfileMapping()
        {
            CreateMap<TicketDto, Ticket>().ReverseMap();

            CreateMap<CreateTicketRequest, Ticket>()
                .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.Created, opt => opt.MapFrom(_ => DateTime.Now))
                .ForMember(dest => dest.IsStatus, opt => opt.MapFrom(_ => true));

            CreateMap<UpdateTicketRequest, Ticket>()
                .ForMember(dest => dest.Updated, opt => opt.MapFrom(_ => DateTime.Now));
        }
    }
}
