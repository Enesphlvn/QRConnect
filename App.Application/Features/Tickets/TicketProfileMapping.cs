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

            CreateMap<CreateTicketRequest, Ticket>();

            CreateMap<UpdateTicketRequest, Ticket>();
        }
    }
}
