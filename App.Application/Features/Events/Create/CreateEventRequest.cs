namespace App.Application.Features.Events.Create;

public record CreateEventRequest(string Name, DateTime Date, decimal Price, string? Description);