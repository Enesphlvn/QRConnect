namespace App.Application.Features.Tickets.Dto;

public record TicketResponse(int Id, int EventId, int UserId, DateTimeOffset PurchaseDate);