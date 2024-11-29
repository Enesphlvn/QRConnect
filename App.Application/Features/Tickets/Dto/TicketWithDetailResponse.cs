using App.Application.Features.Events.Dto;
using App.Application.Features.Users.Dto;

namespace App.Application.Features.Tickets.Dto;

public record TicketWithDetailResponse(int Id, EventResponse Event, UserResponse User, DateTimeOffset PurchaseDate);
