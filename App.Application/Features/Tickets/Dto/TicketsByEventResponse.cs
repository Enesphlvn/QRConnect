using App.Application.Features.Users.Dto;

namespace App.Application.Features.Tickets.Dto;

public record TicketsByEventResponse(int Id, int EventId, UserResponse User, DateTimeOffset PurchaseDate);