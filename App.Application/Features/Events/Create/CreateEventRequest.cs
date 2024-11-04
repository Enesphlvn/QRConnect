namespace App.Application.Features.Events.Create;

public record CreateEventRequest(string Name, DateTime Date, string Address, decimal Price, string? Description); 