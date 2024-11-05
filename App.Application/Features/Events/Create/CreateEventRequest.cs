namespace App.Application.Features.Events.Create;

public record CreateEventRequest(string Name, DateTime Date, string City, string District, decimal Price, string? Description);