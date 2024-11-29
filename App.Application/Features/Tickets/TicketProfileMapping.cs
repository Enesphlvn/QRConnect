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
            CreateMap<TicketResponse, Ticket>().ReverseMap();
            CreateMap<Ticket, TicketsByEventResponse>();
            CreateMap<Ticket, TicketsByUserResponse>();
            CreateMap<CreateTicketRequest, Ticket>()
                .ForMember(dest => dest.PurchaseDate, opt => opt.MapFrom(_ => DateTimeOffset.Now));
            CreateMap<Ticket, TicketWithDetailResponse>();
            CreateMap<UpdateTicketRequest, Ticket>();
        }
    }
}
