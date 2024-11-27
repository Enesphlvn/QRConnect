using App.Application.Features.Events.Dto;

namespace App.Application.Features.Tickets.Dto;

public record TicketsByUserResponse(int Id, EventResponse Event, int UserId, DateTimeOffset PurchaseDate);