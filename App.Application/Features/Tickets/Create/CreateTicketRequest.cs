namespace App.Application.Features.Tickets.Create;

public record CreateTicketRequest(int EventId, int UserId, string QrCode, DateTime PurchaseDate);