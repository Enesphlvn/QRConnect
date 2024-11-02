namespace App.Application.Features.Tickets.Update;

public record UpdateTicketRequest(int EventId, int UserId, string QrCode, DateTime PurchaseDate);