using App.Application.Features.Tickets.Dto;

namespace App.Application.Features.Events.Dto;

public record EventsWithHighestSalesDto(int Id, string Name, DateTime Date, decimal Price, string? Description, int EventTypeId, int VenueId, List<TicketDto> Tickets);