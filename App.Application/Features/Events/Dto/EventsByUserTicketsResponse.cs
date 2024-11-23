using App.Application.Features.Tickets.Dto;

namespace App.Application.Features.Events.Dto;

public record EventsByUserTicketsResponse(int Id, string Name, DateTimeOffset Date, decimal Price, string? Description, int EventTypeId, int VenueId, List<TicketResponse> Tickets);