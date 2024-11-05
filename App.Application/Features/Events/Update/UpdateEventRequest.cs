namespace App.Application.Features.Events.Update;

public record UpdateEventRequest(string Name, DateTime Date, string City, string District, decimal Price, string? Description);